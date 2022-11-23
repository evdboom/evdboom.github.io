using Microsoft.AspNetCore.Components.Web;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Default implementation of the <see cref="IPostContent"/> inerface
    /// </summary>
    public abstract class PostContent : IPostContent
    {
        /// <inheritdoc/>
        public IPost? Post { get; set; }
        /// <summary>
        /// <inheritdoc/>
        /// <para> Can be overridden to provide custom behavior</para>
        /// </summary>
        public virtual IList<IPostContent> ChildContent { get; } = new List<IPostContent>();
        /// <inheritdoc/>
        public IList<string> AdditionalClasses { get; } = new List<string>();
        /// <inheritdoc/>
        public virtual IDictionary<string, object?> Attributes { get; } = new Dictionary<string, object?>();
        /// <inheritdoc/>
        public abstract ComponentType Type { get; }
        /// <inheritdoc/>
        public Style Style { get; set; }    
        /// <inheritdoc/>
        public PositionType TextAlignment { get; set; }
        /// <inheritdoc/>
        public PositionType BlockAlignment { get; set; }
        /// <inheritdoc/>
        public BlogColor Color { get; set; }
        /// <inheritdoc/>
        public Func<MouseEventArgs, Task>? OnClick { get; set; }

        /// <inheritdoc/>
        public string GetClasses()
        {
            var list = GetBaseClassesList() 
                .Concat(GetContentClassesList())
                .Concat(AdditionalClasses)                
                .Distinct()
                .ToList();
            return string.Join(' ', list);
        }

        /// <summary>
        /// The get <see cref="GetClasses"/> method results in the total of the baseclasses, additionalclasses and these optional classes, override to add content specific classes.
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<string> GetContentClassesList()
        {
            yield break;
        }

        /// <summary>
        /// Add the base classes for <see cref="Color"/>, <see cref="BlockAlignment"/>, <see cref="TextAlignment"/> and <see cref="Style"/> properties, classes can be set, overridden or cleared in <see cref="DefaultClasses"/> to influence the behavior (only filled classes are added)
        /// </summary>
        /// <returns></returns>
        protected virtual IEnumerable<string> GetBaseClassesList()
        {
            if (DefaultClasses.ColorClasses.TryGetValue(Color, out string? colorClass))
            {
                yield return colorClass;
            }

            if (DefaultClasses.BlockAlignmentClasses.TryGetValue(BlockAlignment, out string? blockClass))
            {
                yield return blockClass;
            }

            if (DefaultClasses.TextAlignmentClasses.TryGetValue(TextAlignment, out string? textClass))
            {
                yield return textClass;
            }

            var styles = Enum.GetValues<Style>()
                .Where(s => Style.HasFlag(s))
                .Select(s => DefaultClasses.StyleClasses.TryGetValue(s, out string? styleClass) ? styleClass : string.Empty)
                .Where(c => !string.IsNullOrEmpty(c))
                .ToList();

            foreach (var style in styles)
            {
                yield return style;
            }
        }

        /// <summary>
        /// <inheritdoc/>
        /// <para>Override to add additional properties to be set from the builder</para>
        /// </summary>
        /// <param name="builder"></param>
        public virtual void SetProperties(IBuilder builder)
        {            
            if (TextAlignment == PositionType.Inherit)
            {
                TextAlignment = builder.TextAlignment;
            }

            if (Style == Style.Inherit)
            {
                Style = builder.Style;
            }

            if (BlockAlignment == PositionType.Inherit) 
            {
                BlockAlignment = builder.BlockAlignment;
            }

            if (Color == BlogColor.Inherit)
            {
                Color = builder.Color;
            }

            if (OnClick is null)
            { 
                OnClick = builder.OnClick;
            }
        }
    }
}
