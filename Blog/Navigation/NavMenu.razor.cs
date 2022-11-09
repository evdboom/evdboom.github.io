using Blog.PostComponents;
using Microsoft.AspNetCore.Components;

namespace Blog.Navigation
{
    public partial class NavMenu
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
    }
}
