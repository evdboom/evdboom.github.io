using Blog.PostComponents.Line;
using Blog.PostComponents.Link;
using Blog.PostComponents.Paragraph;

namespace Blog.PostComponents.Quote
{
    public class QuoteContent : ParagraphContent
    {
        private string? _title;
        public string? Title
        {
            get => _title;
            set
            {
                _title = value;
                ChildContent = GetChildren()
                    .ToList();
            }
        }

        private string? _source;
        public string? Source
        {
            get => _source;
            set
            {
                _source = value;
                ChildContent = GetChildren()
                    .ToList();
            }
        }

        private string? _link;
        public string? Link
        {
            get => _link;
            set
            {
                _link = value;
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

        public override ComponentType Type => ComponentType.Quote;

        public IEnumerable<PostItemContent> GetChildren()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                yield return new LineContent
                {
                    Style = Enums.Style.Bold,
                    TextPosition = Enums.PositionType.Left,
                    Text = Title
                };
            }
            yield return new LineContent
            {
                Style = Enums.Style.Bordered | Enums.Style.Padded,
                Text = $"\"{Text}\"",
                TextPosition = Enums.PositionType.Center
            };
            if (!string.IsNullOrEmpty(Link))
            {
                yield return new LinkContent
                {
                    TextPosition = Enums.PositionType.Right,
                    Text = Source ?? string.Empty,
                    Href = Link,
                    Style = Enums.Style.Italic,
                    NewTab = true
                };
            }
            else
            {
                yield return new LineContent
                {
                    TextPosition = Enums.PositionType.Right,
                    Text = Source ?? string.Empty,
                    Style = Enums.Style.Italic
                };
            }

        }
    }
}
