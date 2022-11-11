using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.List
{
    public partial class List
    {
        [Parameter]
        public ListContent? Content { get; set; }
    }
}
