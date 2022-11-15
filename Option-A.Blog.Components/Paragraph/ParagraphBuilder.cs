using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Paragraph
{
    public class ParagraphBuilder<Parent> : MainContentBuilderBase<ParagraphBuilder<Parent>, Parent, ParagraphContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;

        public ParagraphBuilder(Parent parent) : base(parent)
        {
        }

        public ParagraphBuilder<Parent> WithText(string text)
        {
            _content.Text = text;
            return this;
        }

        public ParagraphBuilder<Parent> PlaceTextAfterContent()
        {
            _content.TextAfterContent = true;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }

        protected override ParagraphBuilder<Parent> This()
        {
            return this;
        }
    }
}
