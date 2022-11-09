using Blog.Enums;
using Blog.PostComponents.Break;
using Blog.PostComponents.Line;
using Blog.PostComponents.Paragraph;

namespace Blog.PostComponents.Code
{
    public class CodeContent : ParagraphContent
    {
        private string? _language;
        public string? Language 
        {
            get => _language;
            set
            {
                _language = value;
                ChildContent = GetChildren()
                    .ToList();
            }
        }

        public override string Text 
        {
            get => base.Text;
            set
            {
                base.Text = value;
                ChildContent = GetChildren()
                    .ToList();
            }
        }

        public CodeContent() : base()
        {
            Style = Style.Monospace | Style.Padded | Style.Bordered | Style.KeepWhiteSpace;
            TextPosition = PositionType.Left;
            AdditionalClasses = new List<string>
            {
                "code-block"
            };
        }

        private IEnumerable<PostItemContent> GetChildren()
        {
            if (!string.IsNullOrEmpty(Language))
            {
                yield return new LineContent
                {
                    Text = Language,
                    TextPosition = PositionType.Right,
                    Style = Style.Bold | Style.FloatRight
                };
            }

            foreach(var (part, type) in CodePartUtil.GetParts(Text))
            {
                if (type == CodePart.NewLine)
                {
                    yield return new BreakContent();

                }
                else
                {
                    var content = new LineContent
                    {
                        Text = part,
                        BlockType = type == CodePart.Text
                            ? BlockType.Content
                            : BlockType.Inline
                    };
                    if (type != CodePart.Text)
                    {
                        content.AdditionalClasses.Add(type.GetPartClass());
                    }
                    yield return content;
                }
            }
        }

        public override ComponentType Type => ComponentType.Code;
        
    }
}
