﻿using Blog.Posts;

namespace Blog.PostComponents
{
    public class PostService : IPostService
    {
        private readonly Dictionary<string, PostItem> _postsByDateId;
        private readonly Dictionary<string, PostItem> _postsByTitleId;
        private readonly Dictionary<DateTime, List<PostItem>> _postsByMonth;


        public PostService()
        {
            _postsByDateId = new();
            _postsByTitleId = new();
            _postsByMonth = new();

            AddPost(new Post20221103_SetupBlazor());            
        }

        private void AddPost(IPost post)
        {
            _postsByDateId[post.Post.DateId] = post.Post;
            _postsByTitleId[post.Post.TitleId] = post.Post;

            var month = new DateTime(post.Post.PostDate.Year, post.Post.PostDate.Month, 1);
            if (_postsByMonth.ContainsKey(month))
            {
                _postsByMonth[month].Add(post.Post);
            }
            else
            {
                _postsByMonth[month] = new List<PostItem>
                {
                    post.Post
                };
            }
        }

        public PostItem? FindPost(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            id = id.ToLowerInvariant();

            if (_postsByDateId.TryGetValue(id, out PostItem? post))
            {
                return post;
            }
            else if (_postsByTitleId.TryGetValue(id, out post))
            {
                return post;
            }

            return null;
        }

        public IEnumerable<PostItem> EnumeratePosts()
        {
            return _postsByDateId
                .OrderByDescending(p => p.Key)
                .Select(p => p.Value);
        }

        public IEnumerable<PostItem> GetPostsForMonth(int year, int month)
        {
            var dateTime = new DateTime(year, month, 1);
            if (_postsByMonth.TryGetValue(dateTime, out var posts))
            {
                return posts
                    .OrderBy(p => p.PostDate);
            }

            return Enumerable.Empty<PostItem>();
        }
    }
}
