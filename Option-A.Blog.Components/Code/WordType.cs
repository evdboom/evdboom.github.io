namespace OptionA.Blog.Components.Code
{
    /// <summary>
    /// Types of word, depending on format
    /// </summary>
    [Flags]
    public enum WordType
    {
        /// <summary>
        /// Something else
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// Regular string
        /// </summary>
        String = 1,
        /// <summary>
        /// String which might have variables interpolated
        /// </summary>
        Interpolated = 2,
        /// <summary>
        /// Raw string type (currently unsupprted)
        /// </summary>
        Raw = 4,
        /// <summary>
        /// Special marker for setting parser properties
        /// </summary>
        Marker = 8,
        /// <summary>
        /// Start of a comment
        /// </summary>
        Comment = 16,
        /// <summary>
        /// Set this flag if a comment or string is incomplete due to a marker.
        /// </summary>
        Incomplete = 32
    }
}
