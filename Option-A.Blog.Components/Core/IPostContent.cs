using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Interface for post content
    /// </summary>
    public interface IPostContent
    {
        /// <summary>
        /// Child content of this content
        /// </summary>
        IList<IPostContent> ChildContent { get; }
        /// <summary>
        /// List of additional classes to be added to the components
        /// </summary>
        IList<string> AdditionalClasses { get; }
        /// <summary>
        /// Type of component
        /// </summary>
        ComponentType Type { get; }
        /// <summary>
        /// Style of the component
        /// </summary>
        Style Style { get; }
        /// <summary>
        /// Blocktype of the component
        /// </summary>
        BlockType BlockType { get; }
        /// <summary>
        /// Text alignment of the component
        /// </summary>
        PositionType TextAlignment { get; }
        /// <summary>
        /// Block alignment of the component
        /// </summary>
        PositionType BlockAlignment { get; }
        /// <summary>
        /// Color type to use for the component
        /// </summary>
        BlogColor Color { get; }

        /// <summary>
        /// Method to set the properties (Color, Alignment, etc) from the builder to the content
        /// </summary>
        /// <param name="builder"></param>
        void SetProperties(IBuilder builder);
        /// <summary>
        /// Method which results in a single space seperated string of all the classes for this component
        /// </summary>
        /// <returns></returns>
        string GetClasses();
    }
}
