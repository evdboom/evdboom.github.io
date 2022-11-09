using Blog.Builders;
using Blog.Enums;
using Blog.Extensions;

namespace Blog.PostComponents.Paragraph
{
    public static class AddExtensions
    {
        public static PostBuilder AddParagraph(this PostBuilder builder, string text)
        {
            return AddParagraph(builder, text, Style.Normal);
        }

        public static PostBuilder AddParagraph(this PostBuilder builder, string text, Style style)
        {
            return builder.AddContent(new ParagraphContent
            {
                Text = text,
                Style = style
            });
        }

        public static PostBuilder StartParagraph(this PostBuilder builder)
        {
            return StartParagraph(builder, Style.Normal);
        }

        public static PostBuilder StartParagraph(this PostBuilder builder, Style style)
        {
            return builder.StartContent(new ParagraphContent
            {
                Style = style
            });
        }

        public static PostBuilder EndParagraph(this PostBuilder builder)
        {
            return builder.EndContent(ComponentType.Paragraph);
        }
    }
}
