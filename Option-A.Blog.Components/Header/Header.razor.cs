using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace OptionA.Blog.Components.Header
{
    /// <summary>
    /// Header component
    /// </summary>
    public partial class Header
    {
        /// <summary>
        /// Content for component
        /// </summary>
        [Parameter]
        public HeaderContent? Content { get; set; }

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
