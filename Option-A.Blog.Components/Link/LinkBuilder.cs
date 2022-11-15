using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Link
{
    public class LinkBuilder<Parent> : MainContentBuilderBase<LinkBuilder<Parent>, Parent, LinkContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;
        protected override BlogColor _ownColor => BlogColor.Link;

        public LinkBuilder(Parent parent) : base(parent)
        {
        }

        public LinkBuilder<Parent> WithHref(string href)
        {
            _content.Href = href;
            return this;
        }

        public LinkBuilder<Parent> WithText(string text)
        {
            _content.Text = text;
            return this;
        }

        public LinkBuilder<Parent> OpensInNewTab(bool newTab)
        {
            _content.NewTab = newTab;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }

        protected override LinkBuilder<Parent> This()
        {
            return this;
        }
    }
}
