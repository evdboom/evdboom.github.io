using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Image
{
    public partial class Image
    {
        [Parameter]
        public ImageContent? Content { get; set; }
    }
}
