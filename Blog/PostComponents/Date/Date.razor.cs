using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Date
{
    public partial class Date
    {
        [Parameter]
        public DateContent? Content { get; set; }
    }
}
