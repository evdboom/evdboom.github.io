using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices.JavaScript;

namespace OptionA.Blog.Components.Code
{
    public partial class Code
    {
        [Parameter]
        public CodeContent? Content { get; set; }

        [JSImport("navigator.clipboard.writeText")]
        public static partial Task CopyToClipBoard(string text);
    }
}
