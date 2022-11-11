using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.List;

namespace Blog.Builders
{
    public class ListBuilder : BuilderBase<ListBuilder, PostBuilder>
    {
        private readonly ListContent _content;

        private ListBuilder(PostBuilder parent, BlockType blockType, PositionType textAlignment, Style style) : base(parent, blockType, textAlignment, style)
        {
            _content = new();
            SetContentProperties(_content);
        }


        public static ListBuilder CreateList(PostBuilder parent, BlockType blockType, PositionType textAlignment, Style style)
        {
            return new ListBuilder(parent, blockType, textAlignment, style);
        }

        public ListBuilder Ordered()
        {
            _content.Ordered = true;
            return this;
        }

        public ListBuilder Ordered(int startIndex)
        {
            _content.Start = startIndex;
            return Ordered();
        }

        public ListBuilder Horizontal()
        {
            _content.Orientation = Orientation.Horizontal;
            return this;
        }

        public ListBuilder WithStyle(ListStyle listStyle)
        {
            _content.ListStyle = listStyle;
            return this;
        }

        public ListBuilder WithBoldNumbering()
        {
            _content.BoldNumbering = true;
            return this;
        }

        public ListBuilder AddItem(PostItemContent content)
        {
            _content.ChildContent.Add(content);
            SetContentProperties(content);
            return this;
        }

        protected override ListBuilder This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            _result.AddContent(_content);
        }
    }
}
