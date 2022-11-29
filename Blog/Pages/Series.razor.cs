using Microsoft.AspNetCore.Components;

namespace Blog.Pages
{
    public partial class Series
    {
        [Parameter]
        public string? SeriesName { get; set; }
    }
}
