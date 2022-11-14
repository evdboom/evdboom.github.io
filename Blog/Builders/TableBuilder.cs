using Blog.PostComponents;
using Blog.PostComponents.Line;
using Blog.PostComponents.Table;

namespace Blog.Builders
{
    public class TableBuilder<Parent> : SubBuilderBase<TableBuilder<Parent>, Parent, TableContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        public TableBuilder(Parent parent) : base(parent)
        {
            SetContentProperties(_content.Columns);
        }



        public TableBuilder<Parent> WithCaption(string caption)
        {
            if (!string.IsNullOrEmpty(_content.Text))
            {
                throw new InvalidOperationException("Can only set caption once");
            }

            _content.Text = caption;
            return this;
        }

        public TableBuilder<Parent> AddColumns(params string[] columnHeaders)
        {
            foreach (var header in columnHeaders)
            {
                AddColumn(header);
            }

            return this;
        }

        private void AddColumn(string columnHeader)
        {
            var header = new LineContent
            {
                Text = columnHeader
            };
            SetContentProperties(header);
            _content.Columns.ChildContent.Add(header);
        }

        public TableBuilder<Parent> AddRow(RowContent content)
        {
            AddContent(content);
            return this;
        }

        public void AddContent(PostItemContent content)
        {
            _content.ChildContent.Add(content);
            SetContentProperties(content);

        }

        public RowBuilder<Parent> StartRow()
        {
            return new RowBuilder<Parent>(this);
        }

        protected override TableBuilder<Parent> This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            if (!_content.ChildContent.All(c => c.ChildContent.Count == _content.Columns.ChildContent.Count))
            {
                throw new InvalidOperationException($"row parameter count must be equal to columns count ({_content.Columns.ChildContent.Count})");
            }

            base.OnBuild();
        }
    }
}
