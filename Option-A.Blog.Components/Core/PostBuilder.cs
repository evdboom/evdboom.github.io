using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public class PostBuilder : BuilderBase<PostBuilder, Post>, IParentBuilder
    {
        public IPost Post => _result;

        private PostBuilder(Post result) : base(result, Style.Inherit, PositionType.Inherit, BlockType.Normal, PositionType.Inherit, BlogColor.Inherit)
        {
        }

        public static PostBuilder CreatePost(Post post)
        {
            return new PostBuilder(post);
        }

        public PostBuilder WithDate(DateTime date)
        {
            _result.PostDate = date;
            return this;
        }

        public PostBuilder WithDate(int year, int month, int day)
        {
            return WithDate(year, month, day, 0);
        }

        public PostBuilder WithDate(int year, int month, int day, int postNumber)
        {
            return WithDate(new DateTime(year, month, day, postNumber, 0, 0));
        }

        public PostBuilder WithTitle(string title)
        {
            _result.Title = title;
            return this;
        }

        public PostBuilder WithSubtitle(string subtitle)
        {
            _result.Subtitle = subtitle;
            return this;
        }

        public void AddContent(IPostContent content)
        {
            _result.Content.Add(content);
        }

        protected override PostBuilder This()
        {
            return this;
        }
    }
}
