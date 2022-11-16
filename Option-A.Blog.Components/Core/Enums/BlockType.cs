namespace OptionA.Blog.Components.Core.Enums
{
    /// <summary>
    /// Determines the type of tag to use for (mainly) <see cref="Block.Block"/> or derived components.
    /// </summary>
    public enum BlockType
    {
        /// <summary>
        /// Tells the builder to use the blocktype of the parent, if a component is build with this type they might not get rendered
        /// </summary>
        Inherit,
        /// <summary>
        /// Normal block, resulting in a &lt;div&gt; tag for a <see cref="Block.Block"/> or derived components
        /// </summary>
        Block,
        /// <summary>
        /// Inline block, resulting in a &lt;span&gt; tag for a <see cref="Block.Block"/> or derived components
        /// </summary>
        Inline,
        /// <summary>
        /// Render just the content, resulting in a no tag for a <see cref="Block.Block"/> or derived components, this also affects styles set as the component itself will not use these (set through parent)
        /// </summary>
        Content,
        /// <summary>
        /// Paragraph block, similar to <see cref="Block"/>, but results in a &lt;p&gt; tag for a <see cref="Block.Block"/> or derived components
        /// </summary>
        Paragraph
    }
}
