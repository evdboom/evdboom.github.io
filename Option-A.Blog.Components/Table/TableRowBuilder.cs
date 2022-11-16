using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Table
{
    /// <summary>
    /// Builder for creating table rows
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class TableRowBuilder<Parent> : ContentBuilderBase<TableRowBuilder<Parent>, TableBuilder<Parent>, TableRowContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        /// <summary>
        /// Post for which the content is created
        /// </summary>
        public IPost Post => _result.Post;

        public TableRowBuilder(TableBuilder<Parent> parent, bool columns) : base(parent)
        {
            _content.ColumnRow = columns;
        }

        protected override TableRowBuilder<Parent> This()
        {
            return this;
        }

        protected override void OnBuild()
        {
            base.OnBuild();
            _result.AddContent(_content);
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }
    }
}
