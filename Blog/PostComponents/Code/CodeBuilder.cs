using Blog.Builders;

namespace Blog.PostComponents.Code
{
    public class CodeBuilder<Parent> : SubBuilderBase<CodeBuilder<Parent>, Parent, CodeContent>
        where Parent : IParentBuilder
    {
        public CodeBuilder(Parent parent) : base(parent)
        {
        }

        public Parent AddCode(string code)
        {
            return AddCode(string.Empty, code);
        }

        public Parent AddCode(string language, string code)
        {
            _content.Text = code;
            _content.Language = language;
            return Build();
        }

        protected override CodeBuilder<Parent> This()
        {
            return this;
        }
    }
}
