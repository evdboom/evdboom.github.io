using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Quote
{
    public partial class Quote
    {
        [Parameter]
        public QuoteContent? Content { get; set; }
    }
}
