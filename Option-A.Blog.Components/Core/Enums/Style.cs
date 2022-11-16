namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// The various styles that can be applied to a component, multiple styles can be set
    /// </summary>
    [Flags]
    public enum Style
    {
        /// <summary>
        /// Tells the builder to use the style from the parent
        /// </summary>
        Inherit = 0,
        /// <summary>
        /// No (additional) styles set for the component
        /// </summary>
        Normal = 1,
        /// <summary>
        /// Render text bold
        /// </summary>
        Bold = 2,
        /// <summary>
        /// Render text italic
        /// </summary>
        Italic = 4,
        /// <summary>
        /// Underline text
        /// </summary>
        Underline = 8,
        /// <summary>
        /// Strike through text
        /// </summary>
        StrikeThrough = 16,
        /// <summary>
        /// Make text lowercase
        /// </summary>
        LowerCase = 32,
        /// <summary>
        /// Make text uppercase
        /// </summary>
        UpperCase = 64,
        /// <summary>
        /// Use a monospace font
        /// </summary>
        Monospace = 128,
        /// <summary>
        /// Place a border around the block
        /// </summary>
        Bordered = 256,
        /// <summary>
        /// Add padding to the block
        /// </summary>
        Padded = 512,
        /// <summary>
        /// Use a dark theme for the block (not fully supported yet)
        /// </summary>
        Dark = 1024,
        /// <summary>
        /// Make sure to keep any set whitespace
        /// </summary>
        KeepWhiteSpace = 4096,
    }
}
