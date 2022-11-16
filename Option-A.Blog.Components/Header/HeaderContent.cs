using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Header
{
    public class HeaderContent : TextContent
    {
        public HeaderSize HeaderSize { get; set; }
        public override ComponentType Type => ComponentType.Header;
    }
}
