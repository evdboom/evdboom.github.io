using Blog.Builders;
using Blog.Enums;

namespace Blog.PostComponents.Header
{
    public static class AddExtensions
    {
        public static HeaderBuilder<Parent> CreateHeader<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new HeaderBuilder<Parent>(parent);
        }

        public static Parent AddHeader<Parent>(this Parent parent, string text, HeaderSize size) where Parent : IParentBuilder
        {
            return AddHeader(parent, text, size, Style.Inherit);
        }

        public static Parent AddHeader<Parent>(this Parent parent, string text, HeaderSize size, Style style) where Parent : IParentBuilder
        {
            return CreateHeader(parent)
                .AddHeader(text, size, style);            
        }
    }
}
