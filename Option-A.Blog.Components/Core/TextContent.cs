namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Base class for content that has a text property
    /// </summary>
    public abstract class TextContent : PostContent
    {
        /// <summary>
        /// Text to display
        /// </summary>
        public virtual string Text { get; set; } = string.Empty;
        /// <summary>
        /// Boolean to determine where to place the text if also <see cref="PostContent.ChildContent"/> is present, default is before the content
        /// </summary>
        public virtual bool TextAfterContent { get; set; }
    }
}
