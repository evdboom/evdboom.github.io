using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Header
{
    public class HeaderBuilder<Parent> : MainContentBuilderBase<HeaderBuilder<Parent>, Parent, HeaderContent>
        where Parent : IParentBuilder
    {
        protected override BlogColor _ownColor => BlogColor.Header;

        public HeaderBuilder(Parent parent) : base(parent)
        {
        }

        public HeaderBuilder<Parent> WithText(string text)
        {
            _content.Text = text;
            return this;
        }

        public HeaderBuilder<Parent> OfSize(HeaderSize size)
        {
            _content.HeaderSize = size;
            return this;
        }

        protected override HeaderBuilder<Parent> This()
        {
            return this;
        }
    }

}
