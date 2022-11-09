namespace Blog.PostComponents.Table
{
    public class TableContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.Table;
        public override bool SupportsCustomChildContent => false;

        public RowContent Columns { get; set; } = new();

    }
}
