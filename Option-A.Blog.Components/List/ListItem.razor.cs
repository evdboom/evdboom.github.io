using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.List
{
    public partial class ListItem
    {
        [Parameter]
        public ListItemContent? Content { get; set; }
    }
}
