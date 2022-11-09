namespace Blog.PostComponents.Link
{
    public class LinkContent : PostItemContent
    {
        public string Href { get; set; } = string.Empty;
        public bool NewTab { get; set; }
        public override ComponentType Type => ComponentType.Link;
    }
}
