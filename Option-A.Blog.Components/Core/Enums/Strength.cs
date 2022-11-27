namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// Strength for margin, padding etc
    /// </summary>
    public enum Strength
    {
        /// <summary>
        /// Default
        /// </summary>
        Inherit,
        /// <summary>
        /// Lowest strength, should result in lowest applied value
        /// </summary>
        ABit,
        /// <summary>
        /// Should result in more then a bit, but less then avery value
        /// </summary>
        ABitMore,
        /// <summary>
        /// Should result in the average value to apply
        /// </summary>
        Average,
        /// <summary>
        /// Should result in more then average but less then most value
        /// </summary>
        ALot,
        /// <summary>
        /// Higest strength, should result in highest applied value
        /// </summary>
        Most
    }
}
