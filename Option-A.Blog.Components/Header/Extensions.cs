using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Header
{
    public static class Extensions
    {
        public static HeaderBuilder<Parent> CreateHeader<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new HeaderBuilder<Parent>(parent);
        }

        public static Parent AddHeader<Parent>(this Parent parent, string text, HeaderSize size) where Parent : IParentBuilder
        {
            return CreateHeader(parent)
                .OfSize(size)
                .WithText(text)
                .Build();
        }
    }
}
