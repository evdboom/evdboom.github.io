using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Services;
using System;
using OptionA.Blog.Components.Line;

namespace Blog.Pages
{
    public partial class Index
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        private BlockContent? _content;

        protected override void OnInitialized()
        {
            _content = ComponentBuilder
                .CreateBuilder(null)
                    .WithTextAlignment(PositionType.Center)
                    .CreateContent()
                        .CreateHeader()
                            .OfSize(HeaderSize.Two)
                            .WithText("Most recent posts")                           
                            .Build()
                        .AddLine()
                        .Build()
                    .BuildOne<BlockContent>();
        }
    }
}
