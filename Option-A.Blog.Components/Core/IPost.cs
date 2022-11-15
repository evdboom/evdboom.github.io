namespace OptionA.Blog.Components.Core
{
    public interface IPost
    {
        DateTime PostDate { get; }
        string Title { get; }
        string Subtitle { get; }
        string DateId { get; }
        string TitleId { get; }
        IList<IPostContent> Content { get; }
    }
}
