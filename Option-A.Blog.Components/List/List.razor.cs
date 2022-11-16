using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.List
{
    /// <summary>
    /// List component
    /// </summary>
    public partial class List
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public ListContent? Content { get; set; }
    }
}
