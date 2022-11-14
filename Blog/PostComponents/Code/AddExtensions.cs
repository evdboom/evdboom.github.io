using Blog.Builders;

namespace Blog.PostComponents.Code
{
    public static class AddExtensions
    {
        public static CodeBuilder<Parent> CreateCode<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new CodeBuilder<Parent>(parent);
        }

        public static Parent AddCode<Parent>(this Parent parent, string code) where Parent : IParentBuilder
        {
            return AddCode(parent, string.Empty, code);
        }

        public static Parent AddCode<Parent>(this Parent parent, string language, string code) where Parent : IParentBuilder
        {
            return CreateCode(parent)
                .AddCode(language, code);
        }
    }
}
