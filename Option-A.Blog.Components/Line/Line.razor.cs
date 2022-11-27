using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Line
{
    /// <summary>
    /// LineComponent
    /// </summary>
    public partial class Line
    {
        /// <summary>
        /// Content for component
        /// </summary>
        [Parameter]
        public LineContent? Content { get; set; }
    }
}
