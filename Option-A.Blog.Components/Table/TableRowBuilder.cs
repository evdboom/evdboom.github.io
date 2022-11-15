using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Table
{
    public class TableRowBuilder<Parent> : ContentBuilderBase<TableRowBuilder<Parent>, TableBuilder<Parent>, TableRowContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        private readonly bool _columns;

        public IPost Post => _result.Post;

        public TableRowBuilder(TableBuilder<Parent> parent, bool columns) : base(parent, parent.Style, parent.TextAlignment, parent.BlockType, parent.BlockAlignment, parent.Color)
        {
            _columns = columns;
        }

        protected override TableRowBuilder<Parent> This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            base.OnBuild();
            _result.AddContent(_content, _columns);
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }
    }
}
