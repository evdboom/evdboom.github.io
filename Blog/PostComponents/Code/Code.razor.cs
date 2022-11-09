using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Code
{
    public partial class Code
    {
        [Parameter]
        public CodeContent? Content { get; set; }
    }
}
