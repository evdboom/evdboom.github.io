using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// List of post content
    /// </summary>
    public partial class PostList
    {
        /// <summary>
        /// Posts to display
        /// </summary>
        [Parameter]
        public IEnumerable<IPost>? Content { get; set; }
    }
}
