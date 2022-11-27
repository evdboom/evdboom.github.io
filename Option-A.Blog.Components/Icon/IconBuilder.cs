using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Icon
{
    /// <summary>
    /// Builder for an Icon component
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class IconBuilder<Parent> : ContentBuilderBase<IconBuilder<Parent>, Parent, IconContent>
        where Parent : IParentBuilder
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent"></param>
        public IconBuilder(Parent parent) : base(parent)
        {
        }

        /// <inheritdoc/>
        protected override IconBuilder<Parent> This()
        {
            return this;
        }
    }
}
