using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Table
{
    public class TableRowContent : PostContent
    {
        public bool ColumnRow { get; set; }
        public override ComponentType Type => ComponentType.Row;
    }
}
