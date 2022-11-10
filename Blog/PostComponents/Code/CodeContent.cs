using Blog.Enums;
using Blog.PostComponents.Line;
using Blog.PostComponents.Paragraph;

namespace Blog.PostComponents.Code
{
    public class CodeContent : ParagraphContent
    {
        public string? Language { get; set; }
        public override ComponentType Type => ComponentType.Code;
        public override bool SupportsCustomChildContent => false;

        public CodeContent() : base()
        {
            Style = Style.Monospace | Style.Padded | Style.Bordered | Style.KeepWhiteSpace;
            TextPosition = PositionType.Left;
            AdditionalClasses = new List<string>
            {
                "code-block"
            };
        }

        public override void Build(PostItem post)
        {
            Post = post;
            ChildContent = GetChildren(post)
                .ToList();
        }

        private IEnumerable<PostItemContent> GetChildren(PostItem post)
        {
            if (!string.IsNullOrEmpty(Language))
            {
                yield return new LineContent
                {
                    Text = Language,
                    TextPosition = PositionType.Right,
                    Style = Style.Bold | Style.FloatRight,
                    Post = post
                };
            }

            foreach (var (part, type) in CodePartUtil.GetParts(Text))
            {
                var content = new LineContent
                {
                    Text = part,
                    BlockType = type == CodePart.Text
                        ? BlockType.Content
                        : BlockType.Inline,
                    Post = post
                };
                if (type != CodePart.Text)
                {
                    content.AdditionalClasses.Add(type.GetPartClass());
                }
                yield return content;

            }
        }
    }
}
