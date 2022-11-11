using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Line
{
    public static class AddExtensions
    {
        public static PostBuilder AddSpace(this PostBuilder builder)
        {            
            return AddLine(builder, " ");
        }

        public static PostBuilder AddLine(this PostBuilder builder, string text)
        {
            return AddLine(builder, text, Style.Inherit);
        }

        public static PostBuilder AddLine(this PostBuilder builder, string text, Style style)
        {
            return builder.AddContent(new LineContent
            {
                Text = text,
                Style = style
            });
        }

        public static ParagraphBuilder AddSpace(this ParagraphBuilder builder)
        {
            return AddLine(builder, " ");
        }

        public static ParagraphBuilder AddLine(this ParagraphBuilder builder, string text)
        {
            return AddLine(builder, text, Style.Inherit);
        }

        public static ParagraphBuilder AddLine(this ParagraphBuilder builder, string text, Style style)
        {
            return builder.AddContent(new LineContent
            {
                Text = text,
                Style = style
            });
        }


        public static RowBuilder AddCells(this RowBuilder builder, params object?[] cells) 
        {
            return builder.AddCells(cells.Select(cell => new LineContent
            {
                Text = $"{cell}"
            }));
        }

        public static TableBuilder AddRow(this TableBuilder builder, params object?[] cells) 
        {
            var row = builder.StartRow();
            AddCells(row, cells);
            return row.Build();
        }

        public static ListBuilder AddRow(this ListBuilder builder, object? row)
        {
            return builder.AddItem(new LineContent
            {
                Text = $"{row}"
            });
        }
    }
}
