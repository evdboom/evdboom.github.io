using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Compound
{
    /// <summary>
    /// Selector component
    /// </summary>
    public partial class CompoundItem
    {
        /// <summary>
        /// Content of component
        /// </summary>
        [Parameter]
        public IPostContent? Content { get; set; }
    }
}
