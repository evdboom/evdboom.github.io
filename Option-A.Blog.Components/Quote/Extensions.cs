using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Quote
{
    public static class Extensions
    {
        public static QuoteBuilder<Parent> CreateQuote<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new QuoteBuilder<Parent>(parent);
        }    

        public static Parent AddQuote<Parent>(this Parent parent, string quote, string source) where Parent : IParentBuilder
        {
            return AddQuote(parent, quote, source, string.Empty);
        }

        public static Parent AddQuote<Parent>(this Parent parent, string quote, string source, string link) where Parent : IParentBuilder
        {
            return AddQuote(parent, quote, source, link, string.Empty);
        }

        public static Parent AddQuote<Parent>(this Parent parent, string quote, string source, string link, string title) where Parent : IParentBuilder
        {
            return CreateQuote(parent)
                .WithQuote(quote)
                .FromSource(source)
                .WithSourceLink(link)
                .WithTitle(title)
                .Build();
        }
    }
}
