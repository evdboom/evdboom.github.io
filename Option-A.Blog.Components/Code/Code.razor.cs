using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices.JavaScript;

namespace OptionA.Blog.Components.Code
{
    public partial class Code
    {
        [Parameter]
        public CodeContent? Content { get; set; }
    }
}
