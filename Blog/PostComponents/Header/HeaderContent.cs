namespace Blog.PostComponents.Header
{
    public class HeaderContent : PostItemContent
    {
        public HeaderSize HeaderSize { get; set; }
        public override ComponentType Type => ComponentType.Header;
    }
}
