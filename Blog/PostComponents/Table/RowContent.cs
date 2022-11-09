namespace Blog.PostComponents.Table
{
    public class RowContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.Row;
        public override bool SupportsCustomChildContent => true;
    }
}
