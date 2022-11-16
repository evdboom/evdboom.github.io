using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Code
{
    /// <summary>
    /// Code component
    /// </summary>
    public partial class Code
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public CodeContent? Content { get; set; }
    }
}
