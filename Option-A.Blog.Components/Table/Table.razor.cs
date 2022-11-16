using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Table
{
    /// <summary>
    /// Table component
    /// </summary>
    public partial class Table
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public TableContent? Content { get; set; }
        
    }
}
