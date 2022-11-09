using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Table
{
    public partial class Table
    {
        [Parameter]
        public TableContent? Content { get; set; }
        
    }
}
