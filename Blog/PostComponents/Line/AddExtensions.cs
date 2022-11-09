using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Line
{
    public static class AddExtensions
    {
        public static PostBuilder AddSpace(this PostBuilder builder)
        {            
            return AddLine(builder, " ");
        }

        public static PostBuilder AddLine(this PostBuilder builder, string text)
        {
            return AddLine(builder, text, Style.Normal);
        }

        public static PostBuilder AddLine(this PostBuilder builder, string text, Style style)
        {
            return builder.AddContent(new LineContent
            {
                Text = text,
                Style = style
            });
        }

        public static PostBuilder StartLine(this PostBuilder builder)
        {
            return StartLine(builder, Style.Normal);
        }

        public static PostBuilder StartLine(this PostBuilder builder, Style style)
        {
            return builder.StartContent(new LineContent
            {
                Style = style
            });
        }

        public static PostBuilder EndLine(this PostBuilder builder)
        {
            return builder.EndContent(ComponentType.Line);
        }
    }
}
