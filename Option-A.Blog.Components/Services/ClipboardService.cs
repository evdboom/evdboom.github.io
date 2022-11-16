using Microsoft.JSInterop;

namespace OptionA.Blog.Components.Services
{
    /// <inheritdoc/>
    public class ClipboardService : IClipboardService
    {
        private const string CopyTextToClipboardFunction = "copyTextToClipboard";
        private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="jsRuntime"></param>
        public ClipboardService(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
              "import", "./_content/OptionA.Blog.Components/js/clipboard-service.js").AsTask());
        }

        /// <inheritdoc/>
        public async Task CopyTextToClipboard(string text)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync(CopyTextToClipboardFunction, text);
        }
    }
}
