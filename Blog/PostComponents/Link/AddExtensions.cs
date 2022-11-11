using Blog.Builders;
using Blog.Enums;
using Blog.Extensions;

namespace Blog.PostComponents.Link
{
    public static class AddExtensions
    {
        public static PostBuilder AddLink(this PostBuilder builder, string text, string href)
        {
            return AddLink(builder, text, href, true);
        }

        public static PostBuilder AddLink(this PostBuilder builder, string text, string href, bool newTab)
        {
            return AddLink(builder, text, href, Style.Inherit, newTab);
        }

        public static PostBuilder AddLink(this PostBuilder builder, string text, string href, Style style)
        {
            return AddLink(builder, text, href, style, true);
        }

        public static PostBuilder AddLink(this PostBuilder builder, string text, string href, Style style, bool newTab)
        {
            return builder.AddContent(new LinkContent
            {
                Href = href,
                Style = style,
                Text = text,
                NewTab = newTab
            });
        }

        public static ParagraphBuilder AddLink(this ParagraphBuilder builder, string text, string href)
        {
            return AddLink(builder, text, href, true);
        }

        public static ParagraphBuilder AddLink(this ParagraphBuilder builder, string text, string href, bool newTab)
        {
            return AddLink(builder, text, href, Style.Inherit, newTab);
        }

        public static ParagraphBuilder AddLink(this ParagraphBuilder builder, string text, string href, Style style)
        {
            return AddLink(builder, text, href, style, true);
        }

        public static ParagraphBuilder AddLink(this ParagraphBuilder builder, string text, string href, Style style, bool newTab)
        {
            return builder.AddContent(new LinkContent
            {
                Href = href,
                Style = style,
                Text = text,
                NewTab = newTab
            });
        }
    }
}
