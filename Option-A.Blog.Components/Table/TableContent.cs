using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Table
{
    public class TableContent : PostContent
    {
        public override ComponentType Type => ComponentType.Table;

        public TableRowContent Columns { get; set; } = new();

    }
}
