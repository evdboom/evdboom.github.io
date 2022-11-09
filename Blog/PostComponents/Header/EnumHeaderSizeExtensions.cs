namespace Blog.PostComponents.Header
{
    public static class EnumHeaderSizeExtensions
    {
        public static string GetSizeClass(this HeaderSize size)
        {
            return size switch
            {
                HeaderSize.One => "fs-1",
                HeaderSize.Two => "fs-2",
                HeaderSize.Three => "fs-3",
                HeaderSize.Four => "fs-4",
                HeaderSize.Five => "fs-5",
                HeaderSize.Six => "fs-6",
                _ => throw new ArgumentException("Invalid Headersize")
            };
        }
    }
}
