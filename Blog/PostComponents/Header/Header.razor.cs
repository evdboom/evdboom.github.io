using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Header
{
    public partial class Header
    {
        [Parameter]
        public HeaderContent? Content { get; set; }
    }
}
