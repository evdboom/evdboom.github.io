using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Custom
{
    /// <summary>
    /// Wrapper for your own components
    /// </summary>
    public class CustomContent : PostContent
    {
        /// <summary>
        /// Fragment to render
        /// </summary>
        public RenderFragment? Fragment { get; set; }
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Custom;
    }
}
