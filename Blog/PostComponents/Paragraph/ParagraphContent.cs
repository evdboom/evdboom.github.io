namespace Blog.PostComponents.Paragraph
{
    public class ParagraphContent : PostItemContent
    {
        public override ComponentType Type => ComponentType.Paragraph;
        public override bool SupportsCustomChildContent => true;
    }
}
