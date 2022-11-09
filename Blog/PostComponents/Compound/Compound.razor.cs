using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Compound
{
    public partial class Compound
    {
        [Parameter]
        public List<PostItemContent>? Content { get; set; }
    }
}
