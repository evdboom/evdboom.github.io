using Microsoft.AspNetCore.Components.Web;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Core
{
    /// <summary>
    /// Base interface for all builders
    /// </summary>
    public interface IBuilder
    {
        /// <summary>
        /// Gets the currently set <see cref="Enums.Style" /> for this builder, Style is copied to child builders.
        /// </summary>
        Style Style { get; }
        /// <summary>
        /// Gets the currently set <see cref="Enums.PositionType" /> for the text alignment for this builder, TextAlignment is copied to child builders.
        /// </summary>
        PositionType TextAlignment { get; }
        /// <summary>
        /// Gets the currently set <see cref="Enums.PositionType" /> for the block alignment for this builder, BlockAlignment is copied to child builders.
        /// </summary>
        PositionType BlockAlignment { get; }
        /// <summary>
        /// Gets the currently set <see cref="Enums.BlockType" /> for this builder, BlockType is copied to child builders.
        /// </summary>
        BlockType BlockType { get; }
        /// <summary>
        /// Gets the currently set <see cref="Enums.BlogColor" /> for this builder, Color is only copied to child builders that do not have a default color themselves. 
        /// </summary>
        BlogColor Color { get; }
        /// <summary>
        /// Gets the currently set OnClick action for this builder, this is not copied to child builders.
        /// </summary>
        Func<MouseEventArgs,Task>? OnClick { get; }
    }
}
