using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Link
{
    /// <summary>
    /// Link component
    /// </summary>
    public partial class Link
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public LinkContent? Content { get; set; }

        private string Target => Content?.NewTab == true
            ? "_blank"
            : "_self";
    }
}
