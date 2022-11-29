using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Icon;
using OptionA.Blog.Components.Image;
using OptionA.Blog.Components.Services;

namespace Blog.Navigation
{
    public partial class NavMenu
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        private BlockContent? _content;

        protected override void OnInitialized()
        {
            _content = ComponentBuilder
                .CreateBuilder(null)
                .CreateBlock()
                    .AddPadding(Side.X | Side.Bottom, Strength.Three)
                    .AddPadding(Side.Top, Strength.Two)
                    .AddMargin(Side.Bottom, Strength.Two)
                    .CreateInline()
                        .AddClasses("fs-1", "shadowed-text")
                        .CreateIcon()
                            .AddClasses("fs-2", "bi bi-check-circle")
                            .Build()
                        .AddContent(" Option A")
                        .Build()
                        .CreateBlock()
                            .WithBlockAlignment(PositionType.FloatRight)
                            .CreateImage()
                                .WithSource("GitHub-Mark-Light-120px-plus.png", ImageMode.Local)
                            .WithHeight(32)
                                .Build()
                            .CreateImage()
                                .WithSource("LI-In-Bug-white.png", ImageMode.Local)
                                .WithSize(string.Empty, "32")
                                .Build()
                            .Build()
                    .AddClasses("sticky-top", "purple-block", "shadowed-box")
                    .Build()
                .BuildOne<BlockContent>();
        }
    }
}
