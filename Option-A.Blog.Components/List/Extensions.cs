using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.List
{
    public static class Extensions
    {
        public static ListBuilder<Parent> CreateList<Parent>(this Parent parent) where Parent: IParentBuilder
        {
            return new ListBuilder<Parent>(parent);
        }
        public static ListBuilder<Parent> CreateOrderedList<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return CreateList(parent)
                .IsOrdered(true)
                .WithListStyle(ListStyle.Numeric);
        }

        public static ListBuilder<Parent> CreateOrderedList<Parent>(this Parent parent, int start) where Parent : IParentBuilder
        {
            return CreateList(parent)
                .IsOrdered(true)
                .WithListStyle(ListStyle.Numeric)
                .WithStart(start);
        }

        public static ListBuilder<Parent> AddRow<Parent>(this ListBuilder<Parent> parent, object? text) where Parent: IParentBuilder
        {
            return parent
                .CreateRow()
                .WithText($"{text}")
                .Build();
        }  
    }
}
