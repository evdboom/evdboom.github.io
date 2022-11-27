using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Archive
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        [Parameter]
        public int Year { get; set; }
        [Parameter]
        public int Month { get; set; }

    }
}
