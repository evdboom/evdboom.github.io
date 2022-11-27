using OptionA.Blog.Components.Code;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.List;

namespace OptionA.Blog.Components
{
    /// <summary>
    /// Classes used by the various components in this package, override with your own or clear if you do not wish to use the default style and behavior.
    /// </summary>
    public static class DefaultClasses
    {
        /// <summary>
        /// Default class for the encasing block of a <see cref="Code.Code"/>
        /// </summary>
        public static IList<string> CodeBlock { get; set; } = new List<string>
        {
            "oa-code-block",           
        };

        /// <summary>
        /// Default class for the header of a <see cref="Code.Code"/>
        /// </summary>
        public static IList<string> CodeHeaderBlock { get; set; } = new List<string>
        {
            "oa-code-header-block"
        };

        /// <summary>
        /// Default classes selected code parts
        /// </summary>
        public static string? SelectedCode { get; set; } = "oa-code-selected";

        /// <summary>
        /// Default classes for displaying tags
        /// </summary>
        public static IList<string> Tag { get; set; } = new List<string>
        {
            "oa-tag-item",
            "oa-style-uppercase"
        };

        /// <summary>
        /// Default classes for container displaying tags
        /// </summary>
        public static IList<string> TagContainer { get; set; } = new List<string>
        {
            "oa-tag-container",
        };

        /// <summary>
        /// Default classes for container displaying the archive
        /// </summary>
        public static IList<string> ArchiveContainer { get; set; } = new List<string>();

        /// <summary>
        /// Default classes for container headers (Tag container, Archive container)
        /// </summary>
        public static IList<string> ContainerHeader { get; set; } = new List<string>
        {
            "oa-container-header",
            "oa-style-bold",
            "oa-text-center"
        };


        /// <summary>
        /// Default class for diplaying posts in compact mode.
        /// </summary>
        public static IList<string> CompactMode { get; set; } = new List<string>
        {
            "oa-compact-mode"
        };

        /// <summary>
        /// Default classes for the various <see cref="CodePart"/> in a piece of code to better clarify code
        /// </summary>
        public static IDictionary<CodePart, string> CodeClasses { get; set; } = new Dictionary<CodePart, string>
        {
            { CodePart.Keyword, "oa-code-keyword" },
            { CodePart.ControlKeyword, "oa-code-controlkeyword" },
            { CodePart.Method, "oa-code-method" },
            { CodePart.String, "oa-code-string" },
            { CodePart.Comment, "oa-code-comment" }
        };

        /// <summary>
        /// Default classes for the default colors of the components
        /// </summary>
        public static IDictionary<BlogColor, string> ColorClasses { get; set; } = new Dictionary<BlogColor, string>
        {
            { BlogColor.Link, "oa-color-link" },
            { BlogColor.Header, "oa-color-header" },
            { BlogColor.Text, "oa-color-text" },
            { BlogColor.Quote, "oa-color-quote" },
            { BlogColor.Subtle, "oa-color-subtle" },
        };

        /// <summary>
        /// Default classes for the various styles used by components
        /// </summary>
        public static IDictionary<Style, string> StyleClasses { get; set; } = new Dictionary<Style, string>
        {
            { Style.Thin, "oa-style-thin" },
            { Style.Bold, "oa-style-bold" },
            { Style.Italic, "oa-style-italic" },
            { Style.Underline, "oa-style-underline" },
            { Style.StrikeThrough, "oa-style-strikethrough" },
            { Style.LowerCase, "oa-style-lowercase" },
            { Style.UpperCase, "oa-style-uppercase" },
            { Style.Monospace, "oa-style-monospace" },
            { Style.KeepWhiteSpace, "oa-style-keepwhitespace" },
            { Style.NoDecoration, "oa-style-none" },
        };

        /// <summary>
        /// Default classes for the borders to set on components
        /// </summary>
        public static IDictionary<Side, string> BorderClasses { get; set; } = new Dictionary<Side, string>
        {
            { Side.Top, "oa-border-top" },
            { Side.Right, "oa-border-right" },
            { Side.Bottom, "oa-border-bottom" },
            { Side.Left, "oa-border-left" }
        };

        /// <summary>
        /// Default classes for the border radius to set on components
        /// </summary>
        public static IDictionary<Side, string> BorderRadiusClasses { get; set; } = new Dictionary<Side, string>
        {
            { Side.Top | Side.Left, "oa-borderradius-topleft" },
            { Side.Top | Side.Right, "oa-borderradius-topright" },
            { Side.Bottom | Side.Left, "oa-borderradius-bottomleft" },
            { Side.Bottom | Side.Right, "oa-borderradius-bottomright" }
        };

        /// <summary>
        /// Default classes for the margin to be set on components
        /// </summary>
        public static IDictionary<Side, IDictionary<Strength, string>> MarginClasses { get; set; } = new Dictionary<Side, IDictionary<Strength, string>>
        {
            { 
                Side.Top, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-margin-top-1" },
                    { Strength.ABitMore, "oa-margin-top-2" },
                    { Strength.Average, "oa-margin-top-3" },
                    { Strength.ALot, "oa-margin-top-4" },
                    { Strength.Most, "oa-margin-top-5" },
                    { Strength.ABitBelowZero, "oa-neg-margin-top-1" },
                    { Strength.ABitMoreBelowZero, "oa-neg-margin-top-2" },
                    { Strength.BelowZero, "oa-neg-margin-top-3" },
                    { Strength.ALotBelowZero, "oa-neg-margin-top-4" },
                    { Strength.MostBelowZero, "oa-neg-margin-top-5" },
                }
            },
            {
                Side.Right, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-margin-right-1" },
                    { Strength.ABitMore, "oa-margin-right-2" },
                    { Strength.Average, "oa-margin-right-3" },
                    { Strength.ALot, "oa-margin-right-4" },
                    { Strength.Most, "oa-margin-right-5" },
                    { Strength.ABitBelowZero, "oa-neg-margin-right-1" },
                    { Strength.ABitMoreBelowZero, "oa-neg-margin-right-2" },
                    { Strength.BelowZero, "oa-neg-margin-right-3" },
                    { Strength.ALotBelowZero, "oa-neg-margin-right-4" },
                    { Strength.MostBelowZero, "oa-neg-margin-right-5" },
                }
            },
            {
                Side.Bottom, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-margin-bottom-1" },
                    { Strength.ABitMore, "oa-margin-bottom-2" },
                    { Strength.Average, "oa-margin-bottom-3" },
                    { Strength.ALot, "oa-margin-bottom-4" },
                    { Strength.Most, "oa-margin-bottom-5" },
                    { Strength.ABitBelowZero, "oa-neg-margin-bottom-1" },
                    { Strength.ABitMoreBelowZero, "oa-neg-margin-bottom-2" },
                    { Strength.BelowZero, "oa-neg-margin-bottom-3" },
                    { Strength.ALotBelowZero, "oa-neg-margin-bottom-4" },
                    { Strength.MostBelowZero, "oa-neg-margin-bottom-5" },
                }
            },
            {
                Side.Left, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-margin-left-1" },
                    { Strength.ABitMore, "oa-margin-left-2" },
                    { Strength.Average, "oa-margin-left-3" },
                    { Strength.ALot, "oa-margin-left-4" },
                    { Strength.Most, "oa-margin-left-5" },
                    { Strength.ABitBelowZero, "oa-neg-margin-left-1" },
                    { Strength.ABitMoreBelowZero, "oa-neg-margin-left-2" },
                    { Strength.BelowZero, "oa-neg-margin-left-3" },
                    { Strength.ALotBelowZero, "oa-neg-margin-left-4" },
                    { Strength.MostBelowZero, "oa-neg-margin-left-5" },
                }
            },
        };

        /// <summary>
        /// Default classes for the padding to be set on components
        /// </summary>
        public static IDictionary<Side, IDictionary<Strength, string>> PaddingClasses { get; set; } = new Dictionary<Side, IDictionary<Strength, string>>
        {
            {
                Side.Top, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-padding-top-1" },
                    { Strength.ABitMore, "oa-padding-top-2" },
                    { Strength.Average, "oa-padding-top-3" },
                    { Strength.ALot, "oa-padding-top-4" },
                    { Strength.Most, "oa-padding-top-5" },
                }
            },
            {
                Side.Right, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-padding-right-1" },
                    { Strength.ABitMore, "oa-padding-right-2" },
                    { Strength.Average, "oa-padding-right-3" },
                    { Strength.ALot, "oa-padding-right-4" },
                    { Strength.Most, "oa-padding-right-5" },
                }
            },
            {
                Side.Bottom, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-padding-bottom-1" },
                    { Strength.ABitMore, "oa-padding-bottom-2" },
                    { Strength.Average, "oa-padding-bottom-3" },
                    { Strength.ALot, "oa-padding-bottom-4" },
                    { Strength.Most, "oa-padding-bottom-5" },
                }
            },
            {
                Side.Left, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "oa-padding-left-1" },
                    { Strength.ABitMore, "oa-padding-left-2" },
                    { Strength.Average, "oa-padding-left-3" },
                    { Strength.ALot, "oa-padding-left-4" },
                    { Strength.Most, "oa-padding-left-5" },
                }
            },
        };

        /// <summary>
        /// Default classes for the various list styles used by the <see cref="List.List"/> component
        /// </summary>
        public static IDictionary<ListStyle, string> ListStyleClasses { get; set; } = new Dictionary<ListStyle, string>
        {
            { ListStyle.None, "oa-list-style-none" },
            { ListStyle.Circle, "oa-list-style-circle" },
            { ListStyle.OpenCircle, "oa-list-style-opencircle" },
            { ListStyle.Square, "oa-list-style-square" },
            { ListStyle.DisclosureOpen, "oa-list-style-disclosureopen" },
            { ListStyle.DisclosureClosed, "oa-list-style-disclosureclosed" },
            { ListStyle.Numeric, "oa-list-style-numeric" },
            { ListStyle.LowerAlpha, "oa-list-style-loweralpha" },
            { ListStyle.UpperAlpha, "oa-list-style-upperalpha" },
            { ListStyle.UpperRoman, "oa-list-style-upperroman" },
        };

        /// <summary>
        /// Default classes for the text alignment inside a block
        /// </summary>
        public static IDictionary<PositionType, string> TextAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "oa-text-left" },
            { PositionType.Right, "oa-text-right" },
            { PositionType.Center, "oa-text-center" },
        };

        /// <summary>
        /// Default classes for the alignment of a block
        /// </summary>
        public static IDictionary<PositionType, string> BlockAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "oa-block-left" },
            { PositionType.Right, "oa-block-right" },
            { PositionType.Center, "oa-block-center" },
            { PositionType.FloatLeft, "oa-block-floatleft" },
            { PositionType.FloatRight, "oa-block-floatright" }
        };

        /// <summary>
        /// Optional classes for each Content class, they are injected through the builders of the various content classes. If you directly create content classes you have to insert these yourself
        /// </summary>
        public static IDictionary<Type, IList<string>> ContentClasses { get; set; } = new Dictionary<Type, IList<string>>();

        /// <summary>
        /// Adds multiple values to the list if not already present.
        /// </summary>
        /// <param name="list"></param>
        /// <param name="values"></param>
        public static void AddRange(this IList<string> list, params string[] values)
        {
            foreach(var value in values)
            {
                if (!list.Contains(value))
                {
                    list.Add(value);
                }                
            }
        }
    }
}
