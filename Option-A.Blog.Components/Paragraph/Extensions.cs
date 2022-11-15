using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Paragraph
{
    public static class Extensions
    {
        public static ParagraphBuilder<Parent> CreateParagraph<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new ParagraphBuilder<Parent>(parent);
        }

        public static Parent AddParagraph<Parent>(this Parent parent, string text) where Parent : IParentBuilder
        {
            return CreateParagraph(parent)
                .WithText(text)
                .Build();
        }
    }
}
