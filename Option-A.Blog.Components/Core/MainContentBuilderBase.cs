namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Base class for builders can be directly added to the Post (or as child content)
    /// </summary>
    /// <typeparam name="Builder"></typeparam>
    /// <typeparam name="Parent"></typeparam>
    /// <typeparam name="Content"></typeparam>
    public abstract class MainContentBuilderBase<Builder, Parent, Content> : ContentBuilderBase<Builder, Parent, Content>
        where Parent : IParentBuilder
        where Content : IPostContent, new()
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent"></param>
        protected MainContentBuilderBase(Parent parent) : base(parent)
        {
        }
    }
}
