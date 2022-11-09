using Blog.PostComponents;
using System.Reflection;

namespace Blog.Unittests.ActualBlogTests
{
    public class BlogValidation
    {
        private readonly PostService _service;

        public BlogValidation()
        {
            _service = new PostService();
        }

        [Fact]
        public void DateIdsAreUnique()
        {
            var multiple = _service
                .EnumeratePosts()
                .GroupBy(p => p.DateId)
                .Where(g => g.Count() > 1);
            Assert.Empty(multiple);
        }

        [Fact]
        public void TitleIdsAreUnique()
        {
            var multiple = _service
                .EnumeratePosts()
                .GroupBy(p => p.TitleId)
                .Where(g => g.Count() > 1);
            Assert.Empty(multiple);
        }

        [Fact]
        public void AllBlogsHaveValidDateId()
        {
            Assert.All(_service.EnumeratePosts(), post =>
            {
                var expectedId = $"{post.PostDate:yyyyMMdd}";
                Assert.Equal(expectedId, post.DateId);
            });
        }

        [Fact]
        public void AllBlogsHaveValidTitleId()
        {
            Assert.All(_service.EnumeratePosts(), post =>
            {
                var expectedId = post.Title
                    .Replace(" ", "-")
                    .ToLowerInvariant();
                Assert.Equal(expectedId, post.TitleId);
            });
        }

        [Fact]
        public void DatesAreUnique()
        {
            var multiple = _service
                .EnumeratePosts()
                .GroupBy(p => p.PostDate)
                .Where(g => g.Count() > 1);
            Assert.Empty(multiple);
        }

        [Fact]
        public void AllBlogsHaveValidDate()
        {
            foreach (var post in _service.EnumeratePosts())
            {
                Assert.True(post.PostDate > new DateTime(2022, 11, 1));
            }
        }

        [Fact]
        public void AllPostsHaveBeenAdded()
        {
            var all = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .Where(t => string.Equals(t.Namespace, "Blog.Posts", StringComparison.Ordinal))
                .ToArray();

            Assert.All(all, item =>
            {
                Assert.NotNull(_service.FindPost(((IPost)item).Post.DateId));
                Assert.NotNull(_service.FindPost(((IPost)item).Post.TitleId));
            });
        }

        [Fact]
        public void AllBlogsHaveATitle()
        {
            Assert.All(_service.EnumeratePosts(), post =>
            {
                Assert.False(string.IsNullOrEmpty(post.Title));
            });
        }
    }
}
