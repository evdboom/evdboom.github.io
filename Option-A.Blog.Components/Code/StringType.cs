namespace OptionA.Blog.Components.Code
{
    /// <summary>
    /// Types of string, depending on format
    /// </summary>
    public enum StringType
    {
        /// <summary>
        /// No string, somethins else
        /// </summary>
        None,
        /// <summary>
        /// Regular string
        /// </summary>
        Normal,
        /// <summary>
        /// String which might have variables interpolated
        /// </summary>
        Interpolated,
        /// <summary>
        /// Raw string type (currently unsupprted)
        /// </summary>
        Raw
    }
}
