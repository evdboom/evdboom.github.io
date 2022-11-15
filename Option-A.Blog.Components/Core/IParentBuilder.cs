using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    public interface IParentBuilder : IBuilder
    {
        IPost Post { get; }
        void AddContent(IPostContent content);
    }
}
