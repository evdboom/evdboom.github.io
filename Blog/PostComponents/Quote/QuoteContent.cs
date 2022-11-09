using Blog.PostComponents.Line;
using Blog.PostComponents.Link;
using Blog.PostComponents.Paragraph;

namespace Blog.PostComponents.Quote
{
    public class QuoteContent : ParagraphContent
    {
        public string? Title { get; set; }
        public string? Source { get; set; }
        public string? Link { get; set; }

        public override ComponentType Type => ComponentType.Quote;
        public override bool SupportsCustomChildContent => false;

        public override void Build()
        {
            ChildContent = GetChildren()
                .ToList();
        }

        public IEnumerable<PostItemContent> GetChildren()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                yield return new LineContent
                {
                    Style = Enums.Style.Bold,
                    TextPosition = Enums.PositionType.Left,
                    Text = Title,
                    Color = Enums.BlogColor.Header
                };
            }
            yield return new LineContent
            {
                Style = Enums.Style.Bordered | Enums.Style.Padded,
                Text = $"\"{Text}\"",
                TextPosition = Enums.PositionType.Center,
                Color = Enums.BlogColor.Quote
            };
            if (!string.IsNullOrEmpty(Link))
            {
                yield return new LinkContent
                {
                    TextPosition = Enums.PositionType.Center,
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
