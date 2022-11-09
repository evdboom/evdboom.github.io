using Blog.Enums;

namespace Blog.Extensions
{
    public static class EnumStyleExtensions
    {
        private static Dictionary<Style, string> _styles = new()
        {
            { Style.Normal, string.Empty },
            { Style.Bold, "fw-bold" },
            { Style.Italic, "fst-italic" },
            { Style.Underline, "text-decoration-underline" },
            { Style.StrikeThrough, "text-decoration-line-through" },
            { Style.LowerCase, "text-lowercase"  },
            { Style.UpperCase, "text-uppercase" },
            { Style.Monospace, "font-monospace" },
            { Style.Bordered, "border rounded" },
            { Style.Padded, "p-2" },
            { Style.Dark, "text-light bg-dark" },
            { Style.FloatRight, "float-end" },
            { Style.KeepWhiteSpace, "keep-whitespace" }
        };

        public static string GetStyleClasses(this Style style)
        {
            return string.Join(' ', Enum
                .GetValues<Style>()
                .Where(e => style.HasFlag(e))
                .Select(e => _styles[e]));
        }
    }
}
