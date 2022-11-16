using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Table
{
    /// <summary>
    /// Content for the <see cref="Table.Table"/> component
    /// </summary>
    public class TableContent : PostContent
    {
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Table;

        /// <summary>
        /// Columns for the table
        /// </summary>
        public TableRowContent Columns { get; set; } = new();

    }
}
