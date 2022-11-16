﻿namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// Color options for the various components
    /// </summary>
    public enum BlogColor
    {
        /// <summary>
        /// Tells the builder to use the color set by the parent, if a component is rendered with this option, no color will be set (resulting in default page color)
        /// </summary>
        Inherit,
        /// <summary>
        /// Color used for headers
        /// </summary>
        Header,
        /// <summary>
        /// Color used for text
        /// </summary>
        Text,
        /// <summary>
        /// Color used for footers
        /// </summary>
        Footer,
        /// <summary>
        /// Color used for quotes
        /// </summary>
        Quote,
        /// <summary>
        /// Color used for links
        /// </summary>
        Link
    }
}
