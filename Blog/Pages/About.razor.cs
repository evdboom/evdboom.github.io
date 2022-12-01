using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Link;

namespace Blog.Pages
{
    public partial class About
    {
        private readonly DateTime _birthDate = new(1983, 8, 4);
        private BlockContent? _content;

        protected override void OnInitialized()
        {
            _content = ComponentBuilder
                .CreateBuilder()
                    .CreateContent()
                        .WithTextAlignment(PositionType.Center)
                        .AddHeader("About me", HeaderSize.Two)
                        .AddLine()
                        .WithTextAlignment(PositionType.Left)
                        .CreateParagraph()
                            .AddContent($"My name is Erik van der Boom, currently {GetAge()} years old and living in the Netherlands together with my wife and three daughters. I am employed as a .Net developer/consultant (with various prefixes: lead, senior, etc..) at the (very nice!) Dutch company ").AddLink("Cavero", "https://www.cavero.nl").AddContent("  I am also a certified trainer and Azure developer.")
                            .Build()
                        .AddParagraph(@"When encountering a problem or missing feature I dive into the problem to build my own solution instead of using 'of the shelve' solutions. Mostly because I like to understand what is going on and I like to build. This is also how I started programming, I was one of the people who had a Windows Phone (still think UX wise it's the best OS for a phone), but missed a lot of apps, so I learned how to build them and started building. Later turning my hobby in to my profession.")                        
                        .CreateParagraph()
                            .AddContent("This blog is about features I built or that I find interesting and will write about, it will mostly be about (building stuff with) .Net, Azure and things related. (Almost) all features I built I will also post on my github account: ").AddLink("evdboom", "https://github.com/evdboom").AddContent(".")
                            .Build()
                        .CreateParagraph()
                            .AddContent("If you would like to get in touch, send me an e-mail on ").AddLink("erik@option-a.tech", "mailto:erik@option-a.tech").AddContent(" or connect through ").AddLink("LinkedIn", "https://www.linkedin.com/in/evdboom/").AddContent(".")
                            .Build()
                        .AddHeader("Disclaimer", HeaderSize.Four)
                        .AddParagraph("A lot of the features I write about are part of my own learning process and are always available 'as-is' with no actual guarantee, if you see improvements and/or errors please let met know!")
                        .Build()
                    .BuildOne<BlockContent>();

        }

        private string GetAge()
        {
            var today = DateTime.Today;
            return today.Month < _birthDate.Month 
                || (today.Month == _birthDate.Month && today.Day < _birthDate.Day)
                ? $"{today.Year - _birthDate.Year - 1}"
                : $"{today.Year - _birthDate.Year}";
        }
    }
}
