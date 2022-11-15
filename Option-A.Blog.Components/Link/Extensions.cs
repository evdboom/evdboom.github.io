using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Link
{
    public static class Extensions
    {
        public static LinkBuilder<Parent> CreateLink<Parent>(this Parent parent) where Parent : IParentBuilder
        {
            return new LinkBuilder<Parent>(parent);
        }

        public static Parent AddLink<Parent>(this Parent parent, string text, string href) where Parent : IParentBuilder
        {
            return AddLink(parent, text, href, true);
        }

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
