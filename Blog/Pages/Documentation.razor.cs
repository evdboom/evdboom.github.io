using Blog.Client;
using Microsoft.AspNetCore.Components;

namespace Blog.Pages
{
    public partial class Documentation
    {
        private const string ReleaseNoteFolder = "releasenotes";

        [Inject]
        public IPostClient? PostClient { get; set; }
        [Parameter]
        public string? PackageName { get; set; }

        private List<string>? _releaseNotes = null;
        private OptionA.Blazor.Blog.Post? _post = null;

        protected override async Task OnParametersSetAsync()
        {
            if (!string.IsNullOrEmpty(PackageName))
            {
                var posts = await PostClient!.List(nameof(Documentation), PackageName, CancellationToken.None);
                var releaseNotes = posts.FindAll(post => post.StartsWith(ReleaseNoteFolder));

                var mainPost = posts.Find(post => !post.StartsWith(ReleaseNoteFolder));
                if (!string.IsNullOrEmpty(mainPost))
                {
                    _post = await PostClient.Load(mainPost, nameof(Documentation), PackageName, CancellationToken.None);
                }

                _releaseNotes = releaseNotes;
            }
            else
            {
                _releaseNotes = null;
                _post = null;
            }
        }
    }
}