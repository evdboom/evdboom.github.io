using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Line
{
    public class LineBuilder<Parent> : MainContentBuilderBase<LineBuilder<Parent>, Parent, LineContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;

        public LineBuilder(Parent parent) : base(parent)
        {

        }

        public LineBuilder<Parent> WithText(string text) 
        {
            _content.Text = text;
            return this;
        }

        public LineBuilder<Parent> PlaceTextAfterContent()
        {
            _content.TextAfterContent = true;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }

        protected override LineBuilder<Parent> This()
        {
            return this;
        }
    }
}
