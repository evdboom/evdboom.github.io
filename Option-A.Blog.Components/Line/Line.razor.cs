using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Line
{
    public partial class Line
    {
        [Parameter]
        public LineContent? Content { get; set; }
    }
}
