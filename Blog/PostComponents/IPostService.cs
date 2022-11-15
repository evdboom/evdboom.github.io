using OptionA.Blog.Components.Core;

namespace Blog.PostComponents
{
    public interface IPostService
    {
        public IPost? FindPost(string? id);
        public IEnumerable<IPost> EnumeratePosts();
        public IEnumerable<IPost> GetPostsForMonth(int year, int month);
    }
}
