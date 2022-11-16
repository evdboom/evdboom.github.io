﻿namespace OptionA.Blog.Components.List
{
    /// <summary>
    /// List or bullet style for a list
    /// </summary>
    public enum ListStyle
    {
        /// <summary>
        /// No bullet
        /// </summary>
        None,
        /// <summary>
        /// Closed circle
        /// </summary>
        Circle,
        /// <summary>
        /// Open circle
        /// </summary>
        OpenCircle,
        /// <summary>
        /// Square
        /// </summary>
        Square,
        /// <summary>
        /// Triangle down (open list)
        /// </summary>
        DisclosureOpen,
        /// <summary>
        /// Triangle to the right (closed list)
        /// </summary>
        DisclosureClosed,
        /// <summary>
        /// Decimal numbers: 1, 2, 3, ..
        /// </summary>
        Numeric,
        /// <summary>
        /// Lowercase letters: a, b, c, ..
        /// </summary>
        LowerAlpha,
        /// <summary>
        /// Uppercase letters: A, B, C, ..
        /// </summary>
        UpperAlpha,        
        /// <summary>
        /// Uppercase roman numbering: I, II, III, ..
        /// </summary>
        UpperRoman,
    }
}
