using Microsoft.AspNetCore.Components;

namespace OptionA.Blog.Components.Paragraph
{
    public partial class Paragraph
    {
        [Parameter]
        public ParagraphContent? Content { get; set; }
    }
}
