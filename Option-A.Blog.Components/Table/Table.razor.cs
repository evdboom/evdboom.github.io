using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Table
{
    public partial class Table
    {
        [Parameter]
        public TableContent? Content { get; set; }
        
    }
}
