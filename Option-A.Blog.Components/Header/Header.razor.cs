using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Header
{
    public partial class Header
    {
        [Parameter]
        public HeaderContent? Content { get; set; }
    }
}
