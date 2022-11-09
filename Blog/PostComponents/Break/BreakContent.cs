namespace Blog.PostComponents.Break
{
    public class BreakContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.Break;
        public override bool SupportsCustomChildContent => false;
    }
}
