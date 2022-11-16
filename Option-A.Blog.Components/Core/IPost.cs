namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Interface for the resulting post
    /// </summary>
    public interface IPost
    {
        /// <summary>
        /// Date of the post
        /// </summary>
        DateTime PostDate { get; }
        /// <summary>
        /// Title of the post
        /// </summary>
        string Title { get; }
        /// <summary>
        /// Short description
        /// </summary>
        string Subtitle { get; }
        /// <summary>
        /// DateId, should be rendered as yyyyMMddHH from <see cref="PostDate"/>
        /// </summary>
        string DateId { get; }
        /// <summary>
        /// TitleId, should be rendered as the title, in lower characters and the spaces replaced by dashes.
        /// </summary>
        string TitleId { get; }
        /// <summary>
        /// Content of the post
        /// </summary>
        IList<IPostContent> Content { get; }
    }
}
