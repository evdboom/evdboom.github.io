using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Link
{
    /// <summary>
    /// Content for the <see cref="Link.Link"/> component, inherits for <see cref="BlockContent"/>
    /// </summary>
    public class LinkContent : BlockContent
    {
        /// <summary>
        /// Href for the link
        /// </summary>
        public string Href { get; set; } = string.Empty;
        /// <summary>
        /// If true link will open in a new tab
        /// </summary>
        public bool NewTab { get; set; }
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Link;
    }
}
