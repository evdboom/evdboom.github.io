using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public abstract class PostContent : IPostContent
    {
        public virtual IList<IPostContent> ChildContent { get; } = new List<IPostContent>();
        public IList<string> AdditionalClasses { get; } = new List<string>();
        public abstract ComponentType Type { get; }
        public Style Style { get; set; }
        public BlockType BlockType { get; set; }
        public PositionType TextAlignment { get; set; }
        public PositionType BlockAlignment { get; set; }
        public BlogColor Color { get; set; }

        public string GetClasses()
        {
            var list = GetBaseClassesList() 
                .Concat(GetContentClassesList())
                .Concat(AdditionalClasses)                
                .Distinct()
                .ToList();
            return string.Join(' ', list);
        }

        protected virtual IEnumerable<string> GetContentClassesList()
        {
            yield break;
        }

        protected IEnumerable<string> GetBaseClassesList()
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

        public void SetProperties(IBuilder builder)
        {
            if (BlockType == BlockType.Inherit)
            {
                BlockType = builder.BlockType;
            }

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
        }
    }
}
