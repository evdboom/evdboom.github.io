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
        /// Description, will be set as Title and Alt for the image
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Name of the image
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Full source location of the image
        /// </summary>
        public string Source => $"/images/{Post!.DateId}/{Name}";
        /// <summary>
        /// Actual title, returns source of description is empty
        /// </summary>
        public string Title => !string.IsNullOrEmpty(Description)
            ? Description
            : Source;
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Image;
    }
}
