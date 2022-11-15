using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Compound
{
    public partial class Compound
    {
        [Parameter]
        public IList<IPostContent>? Content { get; set; }
    }
}
