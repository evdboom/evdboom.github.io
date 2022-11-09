using Blog.Enums;
using Blog.Extensions;

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
        public abstract bool SupportsCustomChildContent { get; }

        public string GetClasses()
        {           
            return string.Join(' ', GetClassesList());            
        }

        protected virtual List<string> GetClassesList()
        {
            var result = new List<string>();
            var style = Style.GetStyleClasses();
            if (style.Any())
            {
                result.AddRange(style);
            }
            var color = Color.GetForegroundColorClass();
            if (!string.IsNullOrEmpty(color))
            {
                result.Add(color);
            }
            var textPosition = TextPosition.GetTextPositionClass();
            if (!string.IsNullOrEmpty(textPosition))
            {
                result.Add(textPosition);
            }
            if (AdditionalClasses.Any())
            {
                result.AddRange(AdditionalClasses);
            }

            return result;
        }

        public virtual void Build()
        {
            foreach(var item in ChildContent) 
            {
                item.Build();
            }
        }

    }
}
