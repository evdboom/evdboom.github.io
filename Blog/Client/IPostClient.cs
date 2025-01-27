using OptionA.Blazor.Blog;

namespace Blog.Client
{
    public interface IPostClient
    {
        Task<List<string>> List(string container, string folder, Func<string, bool>? filter, CancellationToken cancellationToken);
        Task<List<string>> List(string container, string folder, CancellationToken cancellationToken);
        Task<Post?> Load(string postId, string container, string folder, CancellationToken cancellationToken);
    }
}
