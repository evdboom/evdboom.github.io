using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Base class for a builder of component content
    /// </summary>
    /// <typeparam name="Builder"></typeparam>
    /// <typeparam name="Parent"></typeparam>
    /// <typeparam name="Content"></typeparam>
    public abstract class ContentBuilderBase<Builder, Parent, Content> : BuilderBase<Builder, Parent>
        where Content : IPostContent, new()
        where Parent : IContentParentBuilder
    {
        /// <summary>
        /// Content to be added to the parent builder
        /// </summary>
        protected readonly Content _content;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent"></param>
        protected ContentBuilderBase(Parent parent) : base(parent, parent.Style, parent.TextAlignment, parent.BlockType, parent.BlockAlignment, parent.Color)
        {
            _content = new();
            if (DefaultClasses.ContentClasses.TryGetValue(typeof(Content), out var classes))
            {
                foreach (var className in classes)
                {
                    AddClass(className);
                }
            }
        }

        public Builder WithTitle(string title)
        {
            return WithAttribute("title", title);
        }

        public Builder WithAttribute(string attributeName)
        {
            return WithAttribute(attributeName, null);
        }

        public Builder WithAttribute(string attributeName, object? attributeValue)
        {
            _content.Attributes[attributeName] = attributeValue;
            return This();
        }

        /// <summary>
        /// Method to add a specific class to the Content of this builder.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public Builder AddClass(string? className)
        {
            if (!string.IsNullOrEmpty(className) && !_content.AdditionalClasses.Contains(className))
            {
                _content.AdditionalClasses.Add(className);
            }
            return This();
        }

        /// <summary>
        /// Method to remove a specific class from the Content of this builder.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public Builder RemoveClass(string className)
        {
            if (!string.IsNullOrEmpty(className) && _content.AdditionalClasses.Contains(className))
            {
                _content.AdditionalClasses.Remove(className);
            }
            return This();
        }

        /// <summary>
        /// Overriden OnBuild, sets the content properties and adds it to the parent builder, then performs the base.OnBuild.
        /// </summary>
        protected override void OnBuild()
        {
            _content.SetProperties(this);
            _result.AddContent(_content);
            base.OnBuild();
        }
    }
}
