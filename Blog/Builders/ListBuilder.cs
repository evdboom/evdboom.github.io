using Blog.Enums;
using Blog.PostComponents;
using Blog.PostComponents.List;

namespace Blog.Builders
{
    public class ListBuilder<Parent> : SubBuilderBase<ListBuilder<Parent>, Parent, ListContent>
        where Parent : IParentBuilder
    {
        public ListBuilder(Parent parent) : base(parent)
        {
            
        }

        public ListBuilder<Parent> Ordered()
        {
            _content.Ordered = true;
            return this;
        }

        public ListBuilder<Parent> Ordered(int startIndex)
        {
            _content.Start = startIndex;
            return Ordered();
        }

        public ListBuilder<Parent> Horizontal()
        {
            _content.Orientation = Orientation.Horizontal;
            return this;
        }

        public ListBuilder<Parent> WithStyle(ListStyle listStyle)
        {
            _content.ListStyle = listStyle;
            return this;
        }

        public ListBuilder<Parent> WithBoldNumbering()
        {
            _content.BoldNumbering = true;
            return this;
        }

        public ListBuilder<Parent> AddItem(PostItemContent content)
        {
            _content.ChildContent.Add(content);
            SetContentProperties(content);
            return this;
        }

        protected override ListBuilder<Parent> This()
        {
            return this;
        }


    }
}
