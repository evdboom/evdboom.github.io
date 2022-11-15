using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.Paragraph;

namespace OptionA.Blog.Components.Quote
{
    public class QuoteContent : ParagraphContent
    {
        public string? Title { get; set; }
        public string Quote { get; set; } = string.Empty;
        public string Source { get; set; } = string.Empty;
        public string? Link { get; set; }

        public override ComponentType Type => ComponentType.Quote;
        public override IList<IPostContent> ChildContent => GetChildren()
            .ToList();

            private IEnumerable<IPostContent> GetChildren()
        {
            if (!string.IsNullOrEmpty(Title))
            {
                yield return new HeaderContent
                {
                    BlockType = BlockType.Normal,
                    TextAlignment = TextAlignment,
                    Text = Title,
                    HeaderSize = HeaderSize.Three,
                    Color = BlogColor.Header
                };
            }

            yield return new LineContent
            {
                BlockType = BlockType.Normal,
                Style = Style.Bordered | Style.Padded,
                Text = $"\"{Quote}\"",
                TextAlignment = TextAlignment,
                Color = BlogColor.Quote,
            };

            if (!string.IsNullOrEmpty(Link))
            {
                yield return new LinkContent
                {
                    TextAlignment = TextAlignment,
                    Text = Source,
                    Href = Link,
                    Style = Style.Italic,
                    NewTab = true,
                    Color = BlogColor.Footer,
                    BlockType = BlockType.Normal,
                };
            }
            else
            {
                yield return new LineContent
                {
                    TextAlignment = TextAlignment,
                    Text = Source,
                    Style = Style.Italic,
                    Color = BlogColor.Footer,
                    BlockType = BlockType.Normal,
                };
            }
        }
    }
}
