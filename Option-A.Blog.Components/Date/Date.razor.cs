using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Date
{
    public partial class Date
    {
        [Parameter]
        public DateContent? Content { get; set; }
    }
}
