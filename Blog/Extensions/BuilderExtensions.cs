using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Image;
using OptionA.Blog.Components.Link;

namespace Blog.Extensions
{
    public static class BuilderExtensions
    {
        public static Parent AddLinkImage<Parent>(this Parent parent, string href, LinkMode linkMode, string imageSource, ImageMode imageMode) where Parent : IParentBuilder
        {
            return parent
                .CreateLink()
                    .WithHref(href, linkMode)
                    .CreateImage()
                        .WithBlockAlignment(PositionType.Inherit)
                        .WithSource(imageSource, imageMode)
                        .WithTitle(href)
                        .WithHeight(32)
                        .AddMargin(Side.Left, Strength.Three)
                        .Build()
                    .Build();
        }
    }
}
