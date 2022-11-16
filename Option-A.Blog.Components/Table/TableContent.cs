using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Table
{
    public class TableContent : PostContent
    {
        public override ComponentType Type => ComponentType.Table;

        public TableRowContent Columns { get; set; } = new();

    }
}
