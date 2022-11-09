using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Line
{
    public partial class Line
    {
        [Parameter]
        public LineContent? Content { get; set; }
    }
}
