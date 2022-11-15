namespace OptionA.Blog.Components.Core
{
    public abstract class Post : IPost
    {
        protected Post() 
        {
            var builder = PostBuilder.CreatePost(this);
            OnBuildPost(builder);
            builder.Build();
        }

        public IList<IPostContent> Content { get; } = new List<IPostContent>();

        private DateTime _postDate;
        public DateTime PostDate
        {
            get => _postDate;
            set
            {
                _postDate = value;
                _dateId = $"{_postDate:yyyyMMddHH}";                   
            }
        }

        private string? _title;
        public string Title
        {
            get => _title ?? string.Empty;
            set
            {
                _title = value;
                _titleId = value
                    .Replace(" ", "-")
                    .ToLowerInvariant();
            }
        }

        public string Subtitle { get; set; } = string.Empty;

        private string? _dateId;
        public string DateId => _dateId ?? string.Empty;
        private string? _titleId;
        public string TitleId => _titleId ?? string.Empty;

        public abstract void OnBuildPost(PostBuilder builder);
    }
}
