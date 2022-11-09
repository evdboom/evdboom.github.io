using Blog.Builders;

namespace Blog.PostComponents.Quote
{
    public static class AddExtensions
    {
        public static PostBuilder AddQuote(this PostBuilder builder, string quote, string source)
        {
            return AddQuote(builder, quote, source, string.Empty);
        }

        public static PostBuilder AddQuote(this PostBuilder builder, string quote, string source, string link)
        {
            return AddQuote(builder, quote, source, link, string.Empty);
        }

        public static PostBuilder AddQuote(this PostBuilder builder, string quote, string source, string link, string title)
        {
            return builder.AddContent(new QuoteContent
            {
                Text = quote,
                TextPosition = Enums.PositionType.Center,
                Link = link,
                Source = source,
                Title = title
            });
        }
    }
}
