using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Tag
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Parameter]
        public string? TagName { get; set; }
    }
}
