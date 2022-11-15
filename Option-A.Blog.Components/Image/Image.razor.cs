using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Image
{
    public partial class Image
    {
        [Parameter]
        public ImageContent? Content { get; set; }
    }
}
