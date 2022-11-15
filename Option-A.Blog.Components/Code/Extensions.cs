using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Code
{
    public static class Extensions
    {
        public static CodeBuilder<Parent> CreateCode<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new CodeBuilder<Parent>(parent);
        }

        public static Parent AddCode<Parent> (this Parent parent, CodeLanguage language, string code) where Parent : IParentBuilder
        {
            return CreateCode(parent)
                .ForLanguage(language)
                .WithCode(code)
                .Build();
        }

        public static string GetPartClass(this CodePart part)
        {
            return DefaultClasses.CodeClasses.TryGetValue(part, out string? className)
                ? className
                : string.Empty;
        }

        public static string ToDisplayLanguage(this CodeLanguage language)
        {
            return language switch
            {
                CodeLanguage.CSharp => "c#",
                CodeLanguage.Javascript => "javascript",
                CodeLanguage.Html => "HTML",
                _ => string.Empty
            };
        }
    }
}
