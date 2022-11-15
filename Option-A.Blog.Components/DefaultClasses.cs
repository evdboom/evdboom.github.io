using OptionA.Blog.Components.Code;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.List;

namespace OptionA.Blog.Components
{
    public static class DefaultClasses
    {
        public static string CodeBlock { get; set; } = "code-block";
        public static string CodeHeaderBlock { get; set; } = "code-header-block";


        public static IDictionary<CodePart, string> CodeClasses { get; set; } = new Dictionary<CodePart, string>
        {
            { CodePart.Keyword, "code-keyword" },
            { CodePart.ControlKeyword, "code-controlkeyword" },
            { CodePart.Method, "code-method" },
            { CodePart.String, "code-string" },
            { CodePart.Comment, "code-comment" }
        };

        public static IDictionary<BlogColor, string> ColorClasses { get; set; } = new Dictionary<BlogColor, string>
        {
            { BlogColor.Link, "color-link" },
            { BlogColor.Header, "color-header" },
            { BlogColor.Text, "color-text" },
            { BlogColor.Quote, "color-quote" },
            { BlogColor.Footer, "color-footer" },
        };

        public static IDictionary<Style, string> StyleClasses { get; set; } = new Dictionary<Style, string>
        {
            { Style.Bold, "style-bold" },
            { Style.Italic, "style-italic" },
            { Style.Underline, "style-underline" },
            { Style.StrikeThrough, "style-strikethrough" },
            { Style.LowerCase, "style-lowercase" },
            { Style.UpperCase, "style-uppercase" },
            { Style.Monospace, "style-monospace" },
            { Style.Bordered, "style-bordered" },
            { Style.Padded, "style-padded" },
            { Style.Dark, "style-dark" },
            { Style.KeepWhiteSpace, "style-keepwhitespace" },
        };

        public static IDictionary<ListStyle, string> ListStyleClasses { get; set; } = new Dictionary<ListStyle, string>
        {
            { ListStyle.None, "list-style-none" },
            { ListStyle.Circle, "list-style-circle" },
            { ListStyle.OpenCircle, "list-style-opencircle" },
            { ListStyle.Square, "list-style-square" },
            { ListStyle.DisclosureOpen, "list-style-disclosureopen" },
            { ListStyle.DisclosureClosed, "list-style-disclosureclosed" },
            { ListStyle.Numeric, "list-style-numeric" },
            { ListStyle.LowerAlpha, "list-style-loweralpha" },
            { ListStyle.UpperAlpha, "list-style-upperalpha" },
            { ListStyle.UpperRoman, "list-style-upperroman" },
        };

        public static IDictionary<PositionType, string> TextAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "text-left" },
            { PositionType.Right, "text-right" },
            { PositionType.Center, "text-center" },
        };

        public static IDictionary<PositionType, string> BlockAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "block-left" },
            { PositionType.Right, "block-right" },
            { PositionType.Center, "block-center" },
            { PositionType.FloatLeft, "block-floatleft" },
            { PositionType.FloatRight, "block-floatright" }
        };

        public static IDictionary<Type, IList<string>> ContentClasses { get; set; } = new Dictionary<Type, IList<string>>();

    }
}
