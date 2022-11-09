using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Link
{
    public partial class Link
    {
        [Parameter]
        public LinkContent? Content { get; set; }

        private string Target => Content?.NewTab == true
            ? "_blank"
            : "_self";
    }
}
