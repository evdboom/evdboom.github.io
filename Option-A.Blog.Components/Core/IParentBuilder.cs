using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Interface for builders that support generic child builders, for instance <see cref="Paragraph.ParagraphBuilder{Parent}"/>
    /// </summary>
    public interface IParentBuilder : IContentParentBuilder
    {
    }
}
