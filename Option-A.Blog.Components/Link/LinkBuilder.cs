using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Link
{
    /// <summary>
    /// Builder for the <see cref="LinkContent"/>
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public class LinkBuilder<Parent> : ContentBuilderBase<LinkBuilder<Parent>, Parent, LinkContent>, IParentBuilder
        where Parent : IParentBuilder
    {
        /// <inheritdoc/>
        public IPost? Post => _result.Post;
        /// <summary>
        /// Sets the color to <see cref="BlogColor.Link"/>
        /// </summary>
        protected override BlogColor OwnColor => BlogColor.Link;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="parent"></param>
        public LinkBuilder(Parent parent) : base(parent)
        {
        }

        /// <summary>
        /// Sets the href
        /// </summary>
        /// <param name="href"></param>
        /// <returns></returns>
        public LinkBuilder<Parent> WithHref(string href)
        {
            _content.Href = href;
            return this;
        }

        /// <summary>
        /// Sets the text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public LinkBuilder<Parent> WithText(string text)
        {
            _content.Text = text;
            return this;
        }

        /// <summary>
        /// Sets if the link opens in a new tab
        /// </summary>
        /// <param name="newTab"></param>
        /// <returns></returns>
        public LinkBuilder<Parent> OpensInNewTab(bool newTab)
        {
            _content.NewTab = newTab;
            return this;
        }

        /// <inheritdoc/>
        public void AddContent(IPostContent content)
        {
            _content.ChildContent.Add(content);
        }

        public LinkBuilder<Parent> AddContents(IEnumerable<IPostContent> contents)
        {
            foreach (var content in contents)
            {
                _content.ChildContent.Add(content);
            }
            return this;
        }

        /// <inheritdoc/>
        protected override LinkBuilder<Parent> This()
        {
            return this;
        }
    }
}
