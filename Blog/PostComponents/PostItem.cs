namespace Blog.PostComponents
{
    public class PostItem
    {
        public List<PostItemContent> Content { get; set; } = new();

        private DateTime _postDate;
        public DateTime PostDate
        {
            get => _postDate;
            set
            {
                _postDate = value;
                _dateId = $"{value:yyyyMMdd}";
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
        public string SubTitle { get; set; } = string.Empty;

        private string? _dateId;
        public string DateId => _dateId ?? string.Empty;
        private string? _titleId;
        public string TitleId => _titleId ?? string.Empty;
    }
}
