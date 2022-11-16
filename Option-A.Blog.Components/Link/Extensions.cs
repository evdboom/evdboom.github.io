using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Link
{
    /// <summary>
    /// Extensions for the Link classes
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Creates a new Link builder for the parent
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static LinkBuilder<Parent> CreateLink<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new LinkBuilder<Parent>(parent);
        }

        /// <summary>
        /// Adds a Link to the parent, opens in a new tab
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <param name="parent"></param>
        /// <param name="text"></param>
        /// <param name="href"></param>
        /// <returns></returns>
        public static Parent AddLink<Parent>(this Parent parent, string text, string href) where Parent : IParentBuilder
        {
            return AddLink(parent, text, href, true);
        }

        /// <summary>
        /// Adds a link to the parent
        /// </summary>
        /// <typeparam name="Parent"></typeparam>
        /// <param name="parent"></param>
        /// <param name="text"></param>
        /// <param name="href"></param>
        /// <param name="newTab"></param>
        /// <returns></returns>
        public static Parent AddLink<Parent>(this Parent parent, string text, string href, bool newTab) where Parent : IParentBuilder
        {
            return CreateLink(parent)
                .WithHref(href)
                .WithText(text)
                .OpensInNewTab(newTab)
                .Build();           
        }
    }
}
