using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Compound
{
    public partial class CompoundItem
    {
        [Parameter]
        public PostItemContent? Content { get; set; }
    }
}
