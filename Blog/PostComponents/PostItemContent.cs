using Blog.Enums;

namespace Blog.PostComponents
{
    public abstract class PostItemContent
    {
        public List<PostItemContent> ChildContent { get; set; } = new();
        public PostItemContent? Parent { get; set; }
        public List<string> AdditionalClasses { get; set; } = new();
        public Style Style { get; set; }
        public virtual string Text { get; set; } = string.Empty;
        public BlogColor Color { get; set; }
        public BlockType BlockType { get; set; }
        public PositionType TextPosition { get; set; }
        public PositionType BlockPosition { get; set; }

        public abstract ComponentType Type { get; }

        public string GetAdditionalClasses()
        {
            if (!AdditionalClasses.Any())
            {
                return string.Empty;
            }

            return string.Join(' ', AdditionalClasses);
        }

    }
}
