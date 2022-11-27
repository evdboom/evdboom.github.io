using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Header
{
    /// <summary>
    /// Contents for header components
    /// </summary>
    public partial class HeaderContents
    {
        /// <summary>
        /// Actual contents
        /// </summary>
        [Parameter]
        public HeaderContent? Content { get; set; }
    }
}
