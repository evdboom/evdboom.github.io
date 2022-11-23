using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

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

        private async Task Click(MouseEventArgs args)
        {
            if (Content?.OnClick is null)
            {
                return;
            }

            await Content.OnClick.Invoke(args);
            StateHasChanged();
        }
    }
}
