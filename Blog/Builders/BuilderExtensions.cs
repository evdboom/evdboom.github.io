using Blog.PostComponents.Code;

namespace Blog.Builders
{
    public static class BuilderExtensions
    {
        public static ListBuilder<Parent> CreateList<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new ListBuilder<Parent>(parent);
        }

        public static ParagraphBuilder<Parent> CreateParagraph<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new ParagraphBuilder<Parent>(parent);
        }

        public static TableBuilder<Parent> CreateTable<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new TableBuilder<Parent>(parent);
        }
    }
}
