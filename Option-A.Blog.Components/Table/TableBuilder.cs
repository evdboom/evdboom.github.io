using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.List;

namespace OptionA.Blog.Components.Table
{
    public class TableBuilder<Parent> : MainContentBuilderBase<TableBuilder<Parent>, Parent, TableContent>, IContentParentBuilder
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

        public void AddContent(IPostContent content)
        {
            if (content is not TableRowContent row)
            {
                throw new InvalidOperationException($"Can only add {nameof(TableRowContent)} to a table");
            }

            if (row.ColumnRow)
            {
                _content.Columns = row;
            }
            else
            {
                _content.ChildContent.Add(row);
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
