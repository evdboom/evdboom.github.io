namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// Position types to correctly place the various components and content
    /// </summary>
    public enum PositionType
    {
        /// <summary>
        /// Tells the builder to use the <see cref="PositionType"/> set by the parent builder
        /// </summary>
        Inherit,
        /// <summary>
        /// Position left
        /// </summary>
        Left,
        /// <summary>
        /// Position right
        /// </summary>
        Right,
        /// <summary>
        /// Position center
        /// </summary>
        Center,
        /// <summary>
        /// Float left, in the default this is ignored for the <see cref="PostContent.TextAlignment"/> property
        /// </summary>
        FloatLeft,
        /// <summary>
        /// Float right, in the default this is ignored for the <see cref="PostContent.TextAlignment"/> property
        /// </summary>
        FloatRight,
    }
}
