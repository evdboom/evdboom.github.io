using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Link;

namespace OptionA.Blog.Components.Quote
{
    public class QuoteBuilder<Parent> : MainContentBuilderBase<QuoteBuilder<Parent>, Parent, QuoteContent>
        where Parent : IParentBuilder
    {
        protected override BlogColor _ownColor => BlogColor.Quote;

        public QuoteBuilder(Parent parent) : base(parent)
        {
            _textAlignment = PositionType.Center;
        }

        public QuoteBuilder<Parent> WithTitle(string title)
        {
            _content.Title = title;
            return this;
        }

        public QuoteBuilder<Parent> WithQuote(string quote)
        {
            _content.Quote = quote; 
            return this;
        }
        public QuoteBuilder<Parent> FromSource(string source)
        {
            _content.Source = source;
            return this;
        }
        public QuoteBuilder<Parent> WithSourceLink(string link)
        {
            _content.Link = link;
            return this;
        }

        protected override void OnBuild()
        {
            base.OnBuild();
        }

        protected override QuoteBuilder<Parent> This()
        {
            return this;
        }

        
    }
}
