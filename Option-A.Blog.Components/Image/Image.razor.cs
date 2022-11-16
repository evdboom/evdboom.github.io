using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Image
{
    /// <summary>
    /// Image component
    /// </summary>
    public partial class Image
    {
        /// <summary>
        /// Content of the component
        /// </summary>
        [Parameter]
        public ImageContent? Content { get; set; }
    }
}
