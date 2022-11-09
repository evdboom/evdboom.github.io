using Blog.Extensions;
using Microsoft.AspNetCore.Components;

namespace Blog.PostComponents.Paragraph
{
    public partial class Paragraph
    {
        [Parameter]
        public ParagraphContent? Content { get; set; }        
    }
}
