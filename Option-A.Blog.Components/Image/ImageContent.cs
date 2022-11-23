using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Image
{
    /// <summary>
    /// Content for the <see cref="Image.Image"/> component
    /// </summary>
    public class ImageContent : PostContent
    {        
        /// <summary>
        /// Name of the image
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Full source location of the image
        /// </summary>
        public string Source => $"/images/{Post!.DateId}/{Name}";
        /// <inheritdoc/>
        public override IDictionary<string, object?> Attributes
        {
            get
            {
                var attributes = base.Attributes;                
                if (!attributes.ContainsKey("title"))
                {
                    attributes["title"] = Source;
                }
                if (!attributes.ContainsKey("alt"))
                {
                    attributes["alt"] = attributes["title"];
                }

                attributes["src"] = Source;                

                return attributes;
            }
        }
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Image;
    }
}
