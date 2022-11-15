using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Image
{
    public class ImageBuilder<Parent> : MainContentBuilderBase<ImageBuilder<Parent>, Parent, ImageContent>
        where Parent : IParentBuilder
    {
        public ImageBuilder(Parent parent) : base(parent)
        {
            _content.Post = _result.Post;
            _content.BlockAlignment = PositionType.Center;
        }

        public ImageBuilder<Parent> WithSource(string source)
        {
            _content.Text = source;
            return this;
        }

        public ImageBuilder<Parent> WithDescription(string description)
        {
            _content.Description = description;
            return this;
        }

        protected override ImageBuilder<Parent> This()
        {
            return this;
        }
    }
}
