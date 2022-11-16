using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Block
{
    /// <summary>
    /// Component for inside <see cref="Block.Block"/> component
    /// </summary>
    public partial class BlockContents
    {
        /// <summary>
        /// Content of component
        /// </summary>
        [Parameter]
        public BlockContent? Content { get; set; }
    }
}
