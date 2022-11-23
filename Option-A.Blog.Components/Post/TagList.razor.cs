using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    public partial class TagList
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        /// <summary>
        /// Set to add additional classes to the tag container
        /// </summary>
        [Parameter]
        public IList<string>? AdditionalContainerClasses { get; set; }
        /// <summary>
        /// Set to add additonal classes to each tag
        /// </summary>
        [Parameter]
        public IList<string>? AdditionalTagClasses { get; set; }

        private BlockContent? _content;

        private void ClickTag(string tag)
        {
            Navigation.NavigateTo($"/tags/{tag}");
        }

        /// <summary>
        /// Initialize content
        /// </summary>
        protected override void OnParametersSet()
        {
            var builder = ComponentBuilder
                .CreateBuilder(null)
                    .CreateBlock()
                        .AddClass(DefaultClasses.TagContainer)
                        .AddClasses(AdditionalContainerClasses);            

            foreach(var tag in PostService.GetTags())
            {
                builder
                    .CreateTag(tag)
                        .AddClasses(AdditionalTagClasses)
                        .WithOnClick((e) =>
                        {
                            ClickTag(tag);
                            return Task.CompletedTask;
                        })
                        .Build();
            }
            
            _content = builder              
                        .Build()
                    .BuildOne<BlockContent>();

        }
    }
}
