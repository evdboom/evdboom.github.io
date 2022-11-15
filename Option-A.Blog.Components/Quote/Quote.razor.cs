using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Quote
{
    public partial class Quote
    {
        [Parameter]
        public QuoteContent? Content { get; set; }
    }
}
