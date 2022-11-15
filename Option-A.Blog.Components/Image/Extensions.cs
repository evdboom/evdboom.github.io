using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Image
{
    public static class Extensions
    {
        public static ImageBuilder<Parent> CreateImage<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new ImageBuilder<Parent>(parent);
        }

        public static Parent AddImage<Parent>(this Parent parent, string source) where Parent : IParentBuilder
        {
            return AddImage(parent, source, string.Empty);
        }

        public static Parent AddImage<Parent>(this Parent parent, string source, string description) where Parent : IParentBuilder
        {
            return CreateImage(parent)
                .WithSource(source)
                .WithDescription(description)
                .Build();
        }
    }
}
