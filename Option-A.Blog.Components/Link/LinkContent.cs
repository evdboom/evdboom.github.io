using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Line;

namespace OptionA.Blog.Components.Link
{
    public class LinkContent : LineContent
    {
        public string Href { get; set; } = string.Empty;
        public bool NewTab { get; set; }
        public override ComponentType Type => ComponentType.Link;
    }
}
