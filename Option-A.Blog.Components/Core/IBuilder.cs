using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public interface IBuilder
    {
        Style Style { get; }
        PositionType TextAlignment { get; }
        PositionType BlockAlignment { get; }
        BlockType BlockType { get; }
        BlogColor Color { get; }
    }
}
