using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Header
{
    public class HeaderContent : TextContent
    {
        public HeaderSize HeaderSize { get; set; }
        public override ComponentType Type => ComponentType.Header;
    }
}
