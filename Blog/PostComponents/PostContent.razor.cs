using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents
{
    public partial class PostContent
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Parameter]
        public PostItem? Content { get; set; }
        [Parameter]
        public bool CompactMode { get; set; }

        private void SelectPost()
        {
            Navigation.NavigateTo($"post/{Content?.TitleId}");
        }
    }
}
