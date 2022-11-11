namespace Blog.PostComponents.List
{
    public static class ListStyleExtensions
    {
        public static string GetTypeClass(this ListStyle style)
        {
            return $"list-type-{style}".ToLowerInvariant();
        }
    }
}
