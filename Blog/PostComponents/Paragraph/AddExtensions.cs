using Blog.Builders;
using Blog.Enums;
using Blog.Extensions;

namespace Blog.PostComponents.Paragraph
{
    public static class AddExtensions
    {
        public static PostBuilder AddParagraph(this PostBuilder builder, string text)
        {
            return AddParagraph(builder, text, Style.Inherit);
        }

        public static PostBuilder AddParagraph(this PostBuilder builder, string text, Style style)
        {
            return builder.AddContent(new ParagraphContent
            {
                Text = text,
                Style = style
            });
        }
    }
}
