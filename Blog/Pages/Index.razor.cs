using Blog.PostComponents;
using Microsoft.AspNetCore.Components;

namespace Blog.Pages
{
    public partial class Index
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
    }
}
