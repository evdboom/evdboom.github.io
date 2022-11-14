using Blog.Enums;
using Blog.PostComponents;

namespace Blog.Builders
{
    public interface IParentBuilder
    {
        BlockType BlockType { get; }
        PositionType TextAlignment { get; }
        Style Style { get; }
        void AddContent(PostItemContent content);
    }
}
