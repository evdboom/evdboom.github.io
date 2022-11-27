using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Tag
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Parameter]
        public string? TagName { get; set; }

        private BlockContent? _content;

        protected override void OnParametersSet()
        {
            _content = ComponentBuilder
                .CreateBuilder(null)
                    .WithTextAlignment(PositionType.Center)
                    .CreateContent()
                        .CreateHeader()
                            .OfSize(HeaderSize.Two)
                            .WithText("Posts for ")
                            .AddTag(TagName)
                            .Build()
                        .AddLine()
                        .Build()
                    .BuildOne<BlockContent>();
        }
    }
}
