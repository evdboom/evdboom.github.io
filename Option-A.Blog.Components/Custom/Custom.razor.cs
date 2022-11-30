using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Custom
{
    /// <summary>
    /// Wrapper for custom content
    /// </summary>
    public partial class Custom
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public CustomContent? Content { get; set; }
    }
}
