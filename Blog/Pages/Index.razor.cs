using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Index
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
    }
}
