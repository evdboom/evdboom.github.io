using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Table
{
    public class TableBuilder<Parent> : MainContentBuilderBase<TableBuilder<Parent>, Parent, TableContent>
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;

        public TableBuilder(Parent parent) : base(parent)
        {
        }

        public TableRowBuilder<Parent> WithColumns()
        {
            return new TableRowBuilder<Parent>(this, false);
        }

        public TableBuilder<Parent> AddColumn(IPostContent column)
        {
            _content.Columns.ChildContent.Add(column);
            return this;
        }

        public void AddContent(TableRowContent content, bool columns)
        {
            if (columns)
            {
                _content.Columns = content;
            }
            else
            {
                _content.ChildContent.Add(content);
            }

        }

        public TableRowBuilder<Parent> CreateRow()
        {
            return new TableRowBuilder<Parent>(this, false);
        }

        protected override TableBuilder<Parent> This()
        {
            return this;
        }
    }
}
