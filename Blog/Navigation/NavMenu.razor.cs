using Blog.Extensions;
using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Icon;
using OptionA.Blog.Components.Image;
using OptionA.Blog.Components.Link;
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
                .CreateBuilder()
                .CreateBlock()                 
                    .AddPadding(Side.All, Strength.Three)
                    .CreateInline()
                        .AddClasses("fs-1", "shadowed-text")
                        .CreateLink()
                            .AddClasses("shadowed-box")
                            .WithHref("/", LinkMode.Self)                        
                            .AddBorderRadius(Side.All)
                            .AddMargin(Side.Right, Strength.Three)
                            .CreateImage()
                                .WithBlockAlignment(PositionType.Inherit)
                                .WithSource("LogoOptionA.png", ImageMode.Local)
                                .WithTitle("Home")
                                .WithHeight(45)                                
                                .Build()                                            
                            .Build()
                        .AddContent(" Option A")
                        .Build()
                    .AddNavMenuItem("/", "Home")
                    .AddNavMenuItem("/about", "About")  
                    .AddNavMenuItem("/series/NotImplementedYet", "Series")
                    .CreateBlock()
                        .WithBlockAlignment(PositionType.Right)
                        .AddLinkImage("https://www.linkedin.com/in/evdboom/", LinkMode.NewTab, "LI-In-Bug-white.png", ImageMode.Local)
                        .AddLinkImage("https://github.com/evdboom", LinkMode.NewTab, "GitHub-Mark-Light-120px-plus.png", ImageMode.Local)
                        .CreateLink()
                            .WithHref("mailto:erik@option-a.tech", LinkMode.NewTab)
                            .WithColor(BlogColor.Inherit)
                            .AddClass("nav-item")
                            .CreateIcon()
                                .WithMode(IconMode.Path)
                                .WithSize(32, 32)
                                .WithViewBox(0, 0 , 16, 16)
                                .AddPath(Constants.EnvelopeAtPathOne)
                                .AddPath(Constants.EnvelopeAtPathTwo)
                                .Build()
                            .Build()
                        .Build()
                    .AddClasses("sticky", "purple-block", "shadowed-box")
                    .Build()
                .BuildOne<BlockContent>();
        }
    }
}
