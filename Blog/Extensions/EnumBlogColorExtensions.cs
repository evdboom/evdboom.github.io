using Blog.Enums;

namespace Blog.Extensions
{
    public static class EnumBlogColorExtensions
    {
        private static Dictionary<BlogColor, string> _foreGroundColors = new()
        {
            { BlogColor.Normal, string.Empty },
            { BlogColor.Header, "color-header" },
            { BlogColor.Code, "color-code" },
            { BlogColor.Quote, "color-quote" },
            { BlogColor.Link, "color-link" },
        };

        public static string GetForegroundColorClass(this BlogColor style)
        {
            return _foreGroundColors.TryGetValue(style, out string? colorClass)
                ? colorClass
                : string.Empty;
        }
    }
}
