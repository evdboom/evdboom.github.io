using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Table
{
    /// <summary>
    /// Content of a table row
    /// </summary>
    public class TableRowContent : PostContent
    {
        /// <summary>
        /// True if this is the column (header) tow
        /// </summary>
        public bool ColumnRow { get; set; }
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Row;
    }
}
