using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Header
{
    /// <summary>
    /// Content for the <see cref="Header.Header"/> component
    /// </summary>
    public class HeaderContent : BlockContent
    {
        /// <summary>
        /// Size of the header
        /// </summary>
        public HeaderSize HeaderSize { get; set; }
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Header;
    }
}
