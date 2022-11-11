using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Paragraph;

namespace Blog.Builders
{
    public class ParagraphBuilder : BuilderBase<ParagraphBuilder, PostBuilder>
    {
        private readonly ParagraphContent _content;

        private ParagraphBuilder(PostBuilder parent, BlockType blockType, PositionType textAlignnent, Style style) : base(parent, blockType, textAlignnent, style) 
        {
            _content = new();
            SetContentProperties(_content);
        }

        public static ParagraphBuilder CreateParagraph(PostBuilder parent, BlockType blockType, PositionType textAlignnent, Style style)
        {
            return new ParagraphBuilder(parent, blockType, textAlignnent, style);
        }

        public ParagraphBuilder AddContent(PostItemContent content)
        {
            SetContentProperties(content);
            _content.ChildContent.Add(content);
            return this;
        }

        protected override ParagraphBuilder This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            _result.AddContent(_content);
        }
    }
}
