using Blog.Builders;

namespace Blog.PostComponents.Code
{
    public static class AddExtensions
    {
        public static PostBuilder AddCode(this PostBuilder builder, string code)
        {
            return AddCode(builder, string.Empty, code);
        }

        public static PostBuilder AddCode(this PostBuilder builder, string language, string code)
        {
            return builder.AddContent(new CodeContent
            {
                Text = code,
                Language = language,
            });            
        }
    }
}
