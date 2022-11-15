using Blog.PostComponents;
using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace Blog.Pages
{
    public partial class Post
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Parameter]
        public string? PostId { get; set; }

        private IPost? _currentPost;

        protected override void OnParametersSet()
        {
            if (string.IsNullOrEmpty(PostId))
            {
                Navigation.NavigateTo("404");
            }

            var post = PostService.FindPost(PostId);

            if (post is null)
            {
                Navigation.NavigateTo("404");
            }
            else if (PostId!.ToLowerInvariant() != post.TitleId)
            {
                Navigation.NavigateTo($"Post/{post.TitleId}");
            }
            else
            {
                _currentPost = post;
                StateHasChanged();
            }                        
        }
    }
}
