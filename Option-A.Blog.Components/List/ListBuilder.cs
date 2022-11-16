using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.List
{
    public class ListBuilder<Parent> : MainContentBuilderBase<ListBuilder<Parent>, Parent, ListContent>, IContentParentBuilder
        where Parent : IParentBuilder
    {
        public IPost Post => _result.Post;

        public ListBuilder(Parent parent) : base(parent)
        {
        }

        public ListBuilder<Parent> IsOrdered(bool ordered)
        {
            _content.Ordered = ordered;
            return this;
        }

        public ListBuilder<Parent> WithStart(int start)
        {
            _content.Start = start;
            return this;
        }

        public ListBuilder<Parent> WithListStyle(ListStyle style)
        {
            _content.ListStyle = style;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            if (content is not ListItemContent)
            {
                throw new InvalidOperationException($"Can only add {nameof(ListItemContent)} to a list");
            }

            _content.ChildContent.Add(content);            
        }

        public ListItemBuilder<Parent> CreateRow()
        {
            return new ListItemBuilder<Parent>(this);
        }

        protected override ListBuilder<Parent> This()
        {
            return this;
        }
    }
}
