using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Compound
{
    /// <summary>
    /// ComponentList selector component
    /// </summary>
    public partial class Compound
    {
        /// <summary>
        /// Content in component
        /// </summary>
        [Parameter]
        public IList<IPostContent>? Content { get; set; }
    }
}
