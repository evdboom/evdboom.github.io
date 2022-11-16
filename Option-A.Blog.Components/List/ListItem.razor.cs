using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.List
{
    /// <summary>
    /// List item component
    /// </summary>
    public partial class ListItem
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public ListItemContent? Content { get; set; }
    }
}
