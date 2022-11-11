using Blog.Builders;
using Blog.Enums;
using Blog.Extensions;

namespace Blog.PostComponents.Date
{
    public static class AddExtensions
    {        
        public static PostBuilder AddDate(this PostBuilder builder, DateTime date)
        {
            return AddDate(builder, date, Style.Inherit);
        }

        public static PostBuilder AddDate(this PostBuilder builder, DateTime date, Style style)
        {
            return AddDate(builder, date, DateDisplayType.Date, style);
        }

        public static PostBuilder AddDate(this PostBuilder builder, DateTime date, DateDisplayType display)
        {
            return AddDate(builder, date, display, Style.Inherit);
        }

        public static PostBuilder AddDate(this PostBuilder builder, DateTime date, DateDisplayType display, Style style)
        {
            return builder.AddContent(new DateContent
            {
                Date = date,
                Style = style,
                DisplayType = display,
            });
        }
    }
}
