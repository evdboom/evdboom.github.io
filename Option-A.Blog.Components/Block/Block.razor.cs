using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace OptionA.Blog.Components.Block
{
    /// <summary>
    /// Block component
    /// </summary>
    public partial class Block
    {
        /// <summary>
        /// Content for the component
        /// </summary>
        [Parameter]
        public BlockContent? Content { get; set; }

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
