using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Builder for building child collections.
    /// </summary>
    public class ComponentBuilder : BuilderBase<ComponentBuilder, IList<IPostContent>>, IParentBuilder
    {
        /// <inheritdoc/>
        public IPost Post { get; }

        private ComponentBuilder(IPost post, IList<IPostContent> result, Style style, PositionType textAlignment, BlockType blockType, PositionType blockAlignment, BlogColor color) : base(result, style, textAlignment, blockType, blockAlignment, color)
        {
            Post = post;
        }        

        /// <summary>
        /// Creates a new component builder for building child collections.
        /// </summary>
        /// <returns></returns>
        public static ComponentBuilder CreateBuilder(IPost post)
        {
            return new ComponentBuilder(post, new List<IPostContent>(), Style.Inherit, PositionType.Inherit, BlockType.Block, PositionType.Inherit, BlogColor.Inherit);
        }

        /// <inheritdoc/>
        public void AddContent(IPostContent content)
        {
            _result.Add(content);
        }

        /// <inheritdoc/>
        protected override ComponentBuilder This()
        {
            return this;
        }

        /// <summary>
        /// Builds at most one content of the given type, will throw an exception if more then one content is preset.
        /// </summary>
        /// <typeparam name="Content"></typeparam>
        /// <returns></returns>
        public Content? BuildOne<Content>() where Content : class, IPostContent
        {
            return Build()
                .SingleOrDefault() as Content;
        }
    }
}
