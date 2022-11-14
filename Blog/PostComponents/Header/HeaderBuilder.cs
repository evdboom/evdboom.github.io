using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Header
{
    public class HeaderBuilder<Parent> : SubBuilderBase<HeaderBuilder<Parent>, Parent, HeaderContent>
        where Parent : IParentBuilder
    {
        public HeaderBuilder(Parent parent) : base(parent)
        {
        }

        public Parent AddHeader(string text, HeaderSize size, Style style)
        {
            _content.HeaderSize = size;
            _content.Style = style;
            _content.Text = text;

            return Build();
        }

        protected override HeaderBuilder<Parent> This()
        {
            return this;
        }
    }

}
