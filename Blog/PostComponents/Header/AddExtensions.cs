using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Header
{
    public static class AddExtensions
    {
        public static PostBuilder AddHeader(this PostBuilder builder, string text, HeaderSize size)
        {
            return AddHeader(builder, text, size, Style.Inherit);
        }

        public static PostBuilder AddHeader(this PostBuilder builder, string text, HeaderSize size, Style style)
        {
            return builder.AddContent(new HeaderContent
            {
                HeaderSize = size,
                Style = style,
                Text = text,
            });
        }
    }
}
