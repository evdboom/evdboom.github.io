using Blog.Enums;

namespace Blog.Extensions
{
    public static class EnumPositionTypeExtensions
    {
        public static string GetTextPositionClass(this PositionType position)
        {
            return position switch
            {
                PositionType.Left => "text-start",
                PositionType.Center => "text-center",
                PositionType.Right => "text-end",
                _ => string.Empty
            };
        }

        public static string GetMarginPositionClass(this PositionType position)
        {
            return position switch
            {
                PositionType.Left => "ms-auto",
                PositionType.Center => "mx-auto",
                PositionType.Right => "me-auto",
                _ => string.Empty
            };
        }
    }
}
