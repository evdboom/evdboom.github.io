using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Line
{
    public static class Extensions
    {
        public static LineBuilder<Parent> CreateLine<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new LineBuilder<Parent>(parent);
        }

        public static Parent AddLine<Parent>(this Parent parent, object? text) where Parent : IParentBuilder
        {
            return CreateLine(parent)
                .WithText($"{text}")
                .Build();
        }

        public static Parent AddSpace<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return CreateLine(parent)
                .WithBlockType(BlockType.Content)
                .WithText(" ")
                .Build();
        }

        public static Parent AddFooter<Parent>(this Parent parent, string text) where Parent : IParentBuilder
        {
            return CreateLine(parent)
                .WithBlockType(BlockType.Normal)
                .WithTextAlignment(PositionType.Center)
                .WithColor(BlogColor.Footer)
                .WithStyle(Style.Italic)
                .WithText(text)
                .Build();
        }
    }
}
