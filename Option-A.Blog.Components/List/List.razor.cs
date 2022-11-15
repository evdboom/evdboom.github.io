using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.List
{
    public partial class List
    {
        [Parameter]
        public ListContent? Content { get; set; }
    }
}
