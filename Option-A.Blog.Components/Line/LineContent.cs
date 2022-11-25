using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;

namespace OptionA.Blog.Components.Line
{
    /// <summary>
    /// Content for linecomponent
    /// </summary>
    public class LineContent : PostContent
    {
        /// <inheritdoc/>
        public override ComponentType Type => ComponentType.Line;
    }
}
