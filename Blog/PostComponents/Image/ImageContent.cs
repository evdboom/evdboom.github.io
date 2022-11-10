using Blog.PostComponents.Header;
using Blog.PostComponents.Line;
using Blog.Responsive;

namespace Blog.PostComponents.Image
{
    public class ImageContent : PostItemContent
    {
        public Dimension? Size { get; set; }
        public string? Description { get; set; }
        public string? Header { get; set; }        
        public HeaderSize HeaderSize { get; set; }
        public HeaderContent? HeaderContent => ChildContent.FirstOrDefault(c => c.Type == ComponentType.Header) as HeaderContent;
        public LineContent? FooterContent => ChildContent.FirstOrDefault(c => c.Type == ComponentType.Line) as LineContent;
        public string? Footer { get; set; }
        public string Source => $"/images/{Post!.DateId}/{Text}";
        public string Title => GetTitle();

        private string GetTitle()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                return Description;
            }
            else if (!string.IsNullOrEmpty(Header))
            {
                return Header;
            }
            else
            {
                return Source;
            }
        }

        public override ComponentType Type => ComponentType.Image;
        public override bool SupportsCustomChildContent => false;

        public override void Build(PostItem post)
        {
            Post = post;
            ChildContent = GetChildren(post)
                .ToList();
        }

        private IEnumerable<PostItemContent> GetChildren(PostItem post)
        {
            if (!string.IsNullOrEmpty(Header))
            {
                yield return new HeaderContent
                {
                    Text = Header,
                    HeaderSize = HeaderSize,
                    Color = Enums.BlogColor.Header,
                    Post = post,
                    TextPosition = Enums.PositionType.Center
                };
            }
            if (!string.IsNullOrEmpty(Footer))
            {
                yield return new LineContent
                {
                    Text = Footer,
                    BlockType = Enums.BlockType.Normal,
                    TextPosition = Enums.PositionType.Center,
                    Post = post
                };
            }            
        }
    }
}
