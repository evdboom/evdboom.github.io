using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.List
{
    public class ListItemBuilder<Parent> : ContentBuilderBase<ListItemBuilder<Parent>, ListBuilder<Parent>, ListItemContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;

        public ListItemBuilder(ListBuilder<Parent> parent) : base(parent, parent.Style, parent.TextAlignment, parent.BlockType, parent.BlockAlignment, parent.Color)
        {
        }      
        
        public ListItemBuilder<Parent> WithText(string text) 
        {
            _content.Text = text;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }

        protected override void OnBuild()
        {
            base.OnBuild();
            _result.AddContent(_content);
        }

        protected override ListItemBuilder<Parent> This()
        {
            return this;
        }
    }
}
