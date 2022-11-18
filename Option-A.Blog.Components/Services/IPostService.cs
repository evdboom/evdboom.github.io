using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Services
{
    /// <summary>
    /// Interface for a post service to find and enumerate posts.
    /// </summary>
    public interface IPostService
    {
        /// <summary>
        /// Tries to find a post by either <see cref="IPost.DateId"/> or <see cref="IPost.TitleId"/>
        /// </summary>
        /// <param name="id"></param>
        /// <returns>The <see cref="IPost"/> found, or  null of no post is found</returns>
        public IPost? FindPost(string? id);
        /// <summary>
        /// Returns all the posts, by default in reverse (newest first) order
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPost> EnumeratePosts();
        /// <summary>
        /// Returns all the posts for the given month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public IEnumerable<IPost> GetPostsForMonth(int year, int month);
        /// <summary>
        /// Returns all the months that have posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<DateTime> GetMonthsWithPosts();
        /// <summary>
        /// Returns all the tags used for posts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetTags();
        /// <summary>
        /// Returns all the posts that have the given tag.
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public IEnumerable<IPost> GetPostsForTag(string tag);
    }
}
