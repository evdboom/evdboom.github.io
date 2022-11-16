using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Header
{
    /// <summary>
    /// Header component
    /// </summary>
    public partial class Header
    {
        /// <summary>
        /// Content for component
        /// </summary>
        [Parameter]
        public HeaderContent? Content { get; set; }
    }
}
