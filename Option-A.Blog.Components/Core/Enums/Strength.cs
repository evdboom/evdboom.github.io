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
        One,
        /// <summary>
        /// Should result in more then a bit, but less then avery value
        /// </summary>
        Two,
        /// <summary>
        /// Should result in the average value to apply
        /// </summary>
        Three,
        /// <summary>
        /// Should result in more then average but less then most value
        /// </summary>
        Four,
        /// <summary>
        /// Higest strength, should result in highest applied value
        /// </summary>
        Five,
        /// <summary>
        /// Lowest negative strength (only applies to margin)
        /// </summary>
        MinusOne,
        /// <summary>
        /// A bit more negative strength (only applies to margin)
        /// </summary>
        MinusTwo,
        /// <summary>
        /// Average negative strength (only applies to margin)
        /// </summary>
        MinusThree,
        /// <summary>
        /// A bit more then average negative strength (only applies to margin)
        /// </summary>
        MinusFour,
        /// <summary>
        /// Strongest negative strength (only applies to margin)
        /// </summary>
        MinusFive,
    }
}
