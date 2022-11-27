﻿using OptionA.Blog.Components.Code;
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
        public static string? CodeBlock { get; set; } = "code-block";
        
        /// <summary>
        /// Default class for the header of a <see cref="Code.Code"/>
        /// </summary>
        public static string? CodeHeaderBlock { get; set; } = "code-header-block";

        /// <summary>
        /// Default classes selected code parts
        /// </summary>
        public static string? SelectedCode { get; set; } = "code-selected";

        /// <summary>
        /// Default classes for displaying tags
        /// </summary>
        public static IList<string> Tag { get; set; } = new List<string>
        {
            "tag-item"
        };

        /// <summary>
        /// Default classes for container displaying tags
        /// </summary>
        public static IList<string> TagContainer { get; set; } = new List<string>
        {
            "tag-container",
            "component-container"
        };

        /// <summary>
        /// Default classes for container displaying the archive
        /// </summary>
        public static IList<string> ArchiveContainer { get; set; } = new List<string>
        {
            "component-container"
        };

        /// <summary>
        /// Default classes for container headers (Tag container, Archive container)
        /// </summary>
        public static IList<string> ContainerHeader { get; set; } = new List<string>
        {
            "container-header"
        };


        /// <summary>
        /// Default class for diplaying posts in compact mode.
        /// </summary>
        public static IList<string> CompactMode { get; set; } = new List<string>
        {
            "compact-mode"
        };

        /// <summary>
        /// Default classes for the various <see cref="CodePart"/> in a piece of code to better clarify code
        /// </summary>
        public static IDictionary<CodePart, string> CodeClasses { get; set; } = new Dictionary<CodePart, string>
        {
            { CodePart.Keyword, "code-keyword" },
            { CodePart.ControlKeyword, "code-controlkeyword" },
            { CodePart.Method, "code-method" },
            { CodePart.String, "code-string" },
            { CodePart.Comment, "code-comment" }
        };

        /// <summary>
        /// Default classes for the default colors of the components
        /// </summary>
        public static IDictionary<BlogColor, string> ColorClasses { get; set; } = new Dictionary<BlogColor, string>
        {
            { BlogColor.Link, "color-link" },
            { BlogColor.Header, "color-header" },
            { BlogColor.Text, "color-text" },
            { BlogColor.Quote, "color-quote" },
            { BlogColor.Subtle, "color-subtle" },
        };

        /// <summary>
        /// Default classes for the various styles used by components
        /// </summary>
        public static IDictionary<Style, string> StyleClasses { get; set; } = new Dictionary<Style, string>
        {
            { Style.Thin, "style-thin" },
            { Style.Bold, "style-bold" },
            { Style.Italic, "style-italic" },
            { Style.Underline, "style-underline" },
            { Style.StrikeThrough, "style-strikethrough" },
            { Style.LowerCase, "style-lowercase" },
            { Style.UpperCase, "style-uppercase" },
            { Style.Monospace, "style-monospace" },
            { Style.Bordered, "style-bordered" },
            { Style.KeepWhiteSpace, "style-keepwhitespace" },
            { Style.NoDecoration, "style-none" },
        };

        /// <summary>
        /// Default classes for the margin to be set on components
        /// </summary>
        public static IDictionary<Side, IDictionary<Strength, string>> MarginClasses { get; set; } = new Dictionary<Side, IDictionary<Strength, string>>
        {
            { 
                Side.Top, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "margin-top-1" },
                    { Strength.ABitMore, "margin-top-2" },
                    { Strength.Average, "margin-top-3" },
                    { Strength.ALot, "margin-top-4" },
                    { Strength.Most, "margin-top-5" },
                }
            },
            {
                Side.Right, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "margin-right-1" },
                    { Strength.ABitMore, "margin-right-2" },
                    { Strength.Average, "margin-right-3" },
                    { Strength.ALot, "margin-right-4" },
                    { Strength.Most, "margin-right-5" },
                }
            },
            {
                Side.Bottom, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "margin-bottom-1" },
                    { Strength.ABitMore, "margin-bottom-2" },
                    { Strength.Average, "margin-bottom-3" },
                    { Strength.ALot, "margin-bottom-4" },
                    { Strength.Most, "margin-bottom-5" },
                }
            },
            {
                Side.Left, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "margin-left-1" },
                    { Strength.ABitMore, "margin-left-2" },
                    { Strength.Average, "margin-left-3" },
                    { Strength.ALot, "margin-left-4" },
                    { Strength.Most, "margin-left-5" },
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
                    { Strength.ABit, "padding-top-1" },
                    { Strength.ABitMore, "padding-top-2" },
                    { Strength.Average, "padding-top-3" },
                    { Strength.ALot, "padding-top-4" },
                    { Strength.Most, "padding-top-5" },
                }
            },
            {
                Side.Right, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "padding-right-1" },
                    { Strength.ABitMore, "padding-right-2" },
                    { Strength.Average, "padding-right-3" },
                    { Strength.ALot, "padding-right-4" },
                    { Strength.Most, "padding-right-5" },
                }
            },
            {
                Side.Bottom, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "padding-bottom-1" },
                    { Strength.ABitMore, "padding-bottom-2" },
                    { Strength.Average, "padding-bottom-3" },
                    { Strength.ALot, "padding-bottom-4" },
                    { Strength.Most, "padding-bottom-5" },
                }
            },
            {
                Side.Left, new Dictionary<Strength, string>
                {
                    { Strength.ABit, "padding-left-1" },
                    { Strength.ABitMore, "padding-left-2" },
                    { Strength.Average, "padding-left-3" },
                    { Strength.ALot, "padding-left-4" },
                    { Strength.Most, "padding-left-5" },
                }
            },
        };

        /// <summary>
        /// Default classes for the various list styles used by the <see cref="List.List"/> component
        /// </summary>
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

        /// <summary>
        /// Default classes for the text alignment inside a block
        /// </summary>
        public static IDictionary<PositionType, string> TextAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "text-left" },
            { PositionType.Right, "text-right" },
            { PositionType.Center, "text-center" },
        };

        /// <summary>
        /// Default classes for the alignment of a block
        /// </summary>
        public static IDictionary<PositionType, string> BlockAlignmentClasses { get; set; } = new Dictionary<PositionType, string>
        {
            { PositionType.Left, "block-left" },
            { PositionType.Right, "block-right" },
            { PositionType.Center, "block-center" },
            { PositionType.FloatLeft, "block-floatleft" },
            { PositionType.FloatRight, "block-floatright" }
        };

        /// <summary>
        /// Optional classes for each Content class, they are injected through the builders of the various content classes. If you directly create content classes you have to insert these yourself
        /// </summary>
        public static IDictionary<Type, IList<string>> ContentClasses { get; set; } = new Dictionary<Type, IList<string>>();

    }
}
