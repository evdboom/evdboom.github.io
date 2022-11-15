using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Line;

namespace OptionA.Blog.Components.Table
{
    public static class Extensions
    {
        public static TableBuilder<Parent> CreateTable<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new TableBuilder<Parent>(parent);
        }

        public static TableBuilder<Parent> WithColumns<Parent>(this TableBuilder<Parent> builder, params object?[] columns) where Parent : IParentBuilder
        {
            var columnBuilder = builder.WithColumns();
            foreach(var column in columns) 
            {
                columnBuilder.AddLine(column);
            }
            return columnBuilder
                .Build();
        }

        public static TableBuilder<Parent> AddRow<Parent>(this TableBuilder<Parent> builder, params object?[] cells) where Parent : IParentBuilder
        {
            var rowBuilder = builder.CreateRow();
            foreach (var cell in cells)
            {
                rowBuilder.AddLine(cell);
            }
            return rowBuilder
                .Build();
        }
    }
}
