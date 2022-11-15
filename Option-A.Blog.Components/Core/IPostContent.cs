using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public interface IPostContent
    {
        IList<IPostContent> ChildContent { get; }
        IList<string> AdditionalClasses { get; }
        ComponentType Type { get; }
        Style Style { get; }
        BlockType BlockType { get; }
        PositionType TextAlignment { get; }
        PositionType BlockAlignment { get; }
        BlogColor Color { get; }

        void SetProperties(IBuilder builder);
        string GetClasses();
    }
}
