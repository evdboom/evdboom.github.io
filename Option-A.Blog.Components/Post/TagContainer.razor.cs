using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// Component for displaying most used tags
    /// </summary>
    public partial class TagContainer
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        /// <summary>
        /// Sets the maximum amount of tags to display
        /// </summary>
        [Parameter]
        public int? MaxCount { get; set; }        

        private BlockContent? _content;

        /// <summary>
        /// Initialize content
        /// </summary>
        protected override void OnParametersSet()
        {
            var tags = PostService.GetTags();
            if (MaxCount.HasValue)
            {
                tags = tags.Take(MaxCount.Value);
            }
            _content = ComponentBuilder
                .CreateBuilder(null)
                    .CreateBlock()
                        .AddClasses(DefaultClasses.TagContainer)
                        .CreateBlock()
                            .AddClasses(DefaultClasses.ContainerHeader)
                            .WithText("Most common tags")
                            .Build()
                        .AddTags(tags)
                        .Build()
                    .BuildOne<BlockContent>();
        }
    }
}
