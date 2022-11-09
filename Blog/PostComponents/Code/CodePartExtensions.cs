namespace Blog.PostComponents.Code
{
    public static class CodePartExtensions
    {
        public static string GetPartClass(this CodePart part)
        {
            return $"code-{part}".ToLowerInvariant();
        }
    }
}
