using Blog.Posts;
using OptionA.Blog.Components.Core;
using System.Reflection;

namespace Blog.PostComponents
{
    public class PostService : IPostService
    {
        private readonly Dictionary<string, IPost> _postsByDateId;
        private readonly Dictionary<string, IPost> _postsByTitleId;
        private readonly Dictionary<DateTime, List<IPost>> _postsByMonth;

        private const string PostNamespace = "Blog.Posts";

        public PostService()
        {
            _postsByDateId = new();
            _postsByTitleId = new();
            _postsByMonth = new();

            var postType = typeof(IPost);

            var posts = Assembly
                .GetEntryAssembly()?
                .GetTypes()
                .Where(p => postType.IsAssignableFrom(p) && string.Equals(p.Namespace, PostNamespace))
                .Select(p => Activator.CreateInstance(p) as IPost);

            if (posts is null)
            {
                throw new InvalidOperationException("No posts found");
            }

            foreach (var post in posts)
            {
                AddPost(post);
            }
        }

        private void AddPost(IPost? post)
        {
            if (post is null)
            {
                return;
            }

            _postsByDateId[post.DateId] = post;
            _postsByTitleId[post.TitleId] = post;

            var month = new DateTime(post.PostDate.Year, post.PostDate.Month, 1);
            if (_postsByMonth.ContainsKey(month))
            {
                _postsByMonth[month].Add(post);
            }
            else
            {
                _postsByMonth[month] = new List<IPost>
                {
                    post
                };
            }
        }

        public IPost? FindPost(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            id = id.ToLowerInvariant();

            if (_postsByDateId.TryGetValue(id, out IPost? post))
            {
                return post;
            }
            else if (_postsByTitleId.TryGetValue(id, out post))
            {
                return post;
            }

            return null;
        }

        public IEnumerable<IPost> EnumeratePosts()
        {
            return _postsByDateId
                .OrderByDescending(p => p.Key)
                .Select(p => p.Value);
        }

        public IEnumerable<IPost> GetPostsForMonth(int year, int month)
        {
            var dateTime = new DateTime(year, month, 1);
            if (_postsByMonth.TryGetValue(dateTime, out var posts))
            {
                return posts
                    .OrderBy(p => p.PostDate);
            }

            return Enumerable.Empty<IPost>();
        }
    }
}
