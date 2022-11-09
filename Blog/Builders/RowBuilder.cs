using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Table;

namespace Blog.Builders
{
    public class RowBuilder : BuilderBase<RowBuilder, TableBuilder>
    {        
        private readonly RowContent _row;

        private RowBuilder(TableBuilder parent, BlockType blockType, PositionType textAlignment, Style style) : base(parent, blockType, textAlignment, style)
        {
            _row = new();
            SetContentProperties(_row);
        }

        public RowBuilder AddCells(params PostItemContent[] cells)
        {
            foreach(var cell in cells) 
            {
                AddCell(cell);
            }            
            return this;
        }

        public RowBuilder AddCells(IEnumerable<PostItemContent> cells)
        {
            foreach (var cell in cells)
            {
                AddCell(cell);
            }
            return this;
        }

        public RowBuilder AddCell(PostItemContent cell)
        {
            SetContentProperties(cell);
            _row.ChildContent.Add(cell);
            return this;
        }

        public static RowBuilder StartRow(TableBuilder parent, BlockType blockType, PositionType textAlignment, Style style) 
        {
            return new RowBuilder(parent, blockType, textAlignment, style);
        }

        protected override RowBuilder This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            _result.AddRow(_row);
        }
    }
}
