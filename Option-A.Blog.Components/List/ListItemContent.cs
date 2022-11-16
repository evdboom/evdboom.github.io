using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.List
{
    /// <summary>
    /// Content for the <see cref="ListItem"/> component, inherits from <see cref="BlockContent"/>
    /// </summary>
    public class ListItemContent : BlockContent
    {
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Row;
    }
}
