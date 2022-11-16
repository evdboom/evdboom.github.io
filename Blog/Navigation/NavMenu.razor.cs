using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;

namespace Blog.Navigation
{
    public partial class NavMenu
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
    }
}
