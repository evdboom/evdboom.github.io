namespace OptionA.Blog.Components.Services
{
    /// <summary>
    /// Service for accessing the clipboard
    /// </summary>
    public interface IClipboardService
    {
        /// <summary>
        /// Copies the given text to the clipboard
        /// </summary>
        /// <param name="text">text to be copied</param>
        /// <returns></returns>
        Task CopyTextToClipboard(string text);
    }
}
