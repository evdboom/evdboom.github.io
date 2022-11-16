namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// Determines the type of tag to use for (mainly) <see cref="Line.Line"/> or derived components.
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// Tells the builder to use the blocktype of the parent, if a component is build with this type they might not get rendered
        /// </summary>
        Inherit,
        /// <summary>
        /// Normal block, resulting in a &lt;div&gt; tag for a <see cref="Line.Line"/> or derived components
        /// </summary>
        Normal,
        /// <summary>
        /// Inline block, resulting in a &lt;span&gt; tag for a <see cref="Line.Line"/> or derived components
        /// </summary>
        Inline,
        /// <summary>
        /// Render just the, resulting in a no tag for a <see cref="Line.Line"/> or derived components, this also affects styles set as the component itself will not use these (set through parent)
        /// </summary>
        Content,
    }
}
