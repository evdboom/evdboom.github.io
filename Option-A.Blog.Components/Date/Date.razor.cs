using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Date
{
    /// <summary>
    /// Date component
    /// </summary>
    public partial class Date
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public DateContent? Content { get; set; }
    }
}
