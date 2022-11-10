using Blog.Builders;
using Blog.PostComponents.Header;

namespace Blog.PostComponents.Image
{
    public static class AddExtensions
    {
        public static PostBuilder AddImage(this PostBuilder builder, string source)
        {
            return AddImage(builder, source, string.Empty);
        }

        public static PostBuilder AddImage(this PostBuilder builder, string source, string description)
        {
            return AddImage(builder, source, description, string.Empty, default);
        }

        public static PostBuilder AddImage(this PostBuilder builder, string source, string description, string header, HeaderSize headerSize)
        {
            return AddImage(builder, source, description, header, headerSize, string.Empty);
        }

        public static PostBuilder AddImage(this PostBuilder builder, string source, string description, string header, HeaderSize headerSize, string footer)
        {
            return builder.AddContent(new ImageContent
            {
                Text = source,
                Description = description,
                Header = header,
                HeaderSize = headerSize,
                Footer = footer
            });
        }
    }
}
