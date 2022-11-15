using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Image
{
    public class ImageContent : TextContent
    {
        public IPost? Post { get; set; }
        public string? Description { get; set; }
        public string Source => $"/images/{Post!.DateId}/{Text}";
        public string Title => !string.IsNullOrEmpty(Description)
            ? Description
            : Source;

        public override ComponentType Type => ComponentType.Image;
    }
}
