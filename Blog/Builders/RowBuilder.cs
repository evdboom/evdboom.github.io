using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.Table;

namespace Blog.Builders
{
    public class RowBuilder<Parent> : SubBuilderBase<RowBuilder<Parent>, TableBuilder<Parent>, RowContent>
        where Parent : IParentBuilder
    {        
        public RowBuilder(TableBuilder<Parent> parent) : base(parent)
        {
        }

        public RowBuilder<Parent> AddCells(params PostItemContent[] cells)
        {
            foreach(var cell in cells) 
            {
                AddCell(cell);
            }            
            return this;
        }

        public RowBuilder<Parent> AddCells(IEnumerable<PostItemContent> cells)
        {
            foreach (var cell in cells)
            {
                AddCell(cell);
            }
            return this;
        }

        public RowBuilder<Parent> AddCell(PostItemContent cell)
        {
            SetContentProperties(cell);
            _content.ChildContent.Add(cell);
            return this;
        }

        protected override RowBuilder<Parent> This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            _result.AddRow(_content);
        }
    }
}
