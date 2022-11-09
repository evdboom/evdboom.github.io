namespace Blog.PostComponents
{
    public interface IPostService
    {
        public PostItem? FindPost(string? id);
        public IEnumerable<PostItem> EnumeratePosts();
        public IEnumerable<PostItem> GetPostsForMonth(int year, int month);
    }
}
