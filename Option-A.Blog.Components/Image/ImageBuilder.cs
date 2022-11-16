using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Image
{
    /// <summary>
    /// Builder for the <see cref="ImageContent"/>
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class ImageBuilder<Parent> : ContentBuilderBase<ImageBuilder<Parent>, Parent, ImageContent>
        where Parent : IParentBuilder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent"></param>
        public ImageBuilder(Parent parent) : base(parent)
        {
            _content.Post = _result.Post;
            _content.BlockAlignment = PositionType.Center;
        }

        /// <summary>
        /// Sets the image source
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public ImageBuilder<Parent> WithSource(string source)
        {
            _content.Name = source;
            return this;
        }

        /// <summary>
        /// Sets the image description
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        public ImageBuilder<Parent> WithDescription(string description)
        {
            _content.Description = description;
            return this;
        }

        /// <inheritdoc/>
        protected override ImageBuilder<Parent> This()
        {
            return this;
        }
    }
}
