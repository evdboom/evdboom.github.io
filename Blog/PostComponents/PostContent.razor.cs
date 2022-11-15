using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace Blog.PostComponents
{
    public partial class PostContent
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        [Parameter]
        public IPost? Content { get; set; }
        [Parameter]
        public bool CompactMode { get; set; }

        private void SelectPost()
        {
            Navigation.NavigateTo($"post/{Content?.TitleId}");
        }
    }
}
