using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Block
{
    /// <summary>
    /// Content for the <see cref="Block.Block"/> component
    /// </summary>
    public class BlockContent : PostContent
    {
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Block;
        /// <inheritdoc/>
        public BlockType BlockType { get; set; }
        /// <summary>
        /// Text to display override for custom behavior
        /// </summary>
        public virtual string Text { get; set; } = string.Empty;
        /// <summary>
        /// Boolean to determine where to place the text if also <see cref="PostContent.ChildContent"/> is present, default is before the content
        /// </summary>
        public bool TextAfterContent { get; set; }
    }
}
