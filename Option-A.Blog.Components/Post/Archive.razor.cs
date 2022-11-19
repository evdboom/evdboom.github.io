using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    public partial class Archive
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        private string? GetClasses()
        {
            return DefaultClasses.ListStyleClasses.TryGetValue(ListStyle.DisclosureClosed, out var classes)
                ? classes
                : string.Empty;
        }
    }


}
