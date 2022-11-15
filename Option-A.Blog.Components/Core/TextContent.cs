namespace OptionA.Blog.Components.Core
{
    public abstract class TextContent : PostContent
    {
        public virtual string Text { get; set; } = string.Empty;
        public virtual bool TextAfterContent { get; set; }
    }
}
