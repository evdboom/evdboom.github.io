using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Compound
{
    public partial class CompoundItem
    {
        [Parameter]
        public IPostContent? Content { get; set; }
    }
}
