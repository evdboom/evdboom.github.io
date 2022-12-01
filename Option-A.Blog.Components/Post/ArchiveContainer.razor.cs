using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// Archive component
    /// </summary>
    public partial class ArchiveContainer
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        private BlockContent? _content;

        /// <summary>
        /// Initialize content
        /// </summary>
        protected override void OnParametersSet()
        {
            var months = PostService.GetMonthsWithPosts();

            var listBuilder = ComponentBuilder
                .CreateBuilder()
                    .CreateBlock()
                        .AddClasses(DefaultClasses.ArchiveContainer)
                        .CreateList()
                            .WithListStyle(ListStyle.DisclosureClosed);
            
            foreach ( var month in months ) 
            {
                listBuilder
                    .CreateRow()
                        .CreateLink()
                            .WithHref($"/archive/{month.Year}/{month.Month}")
                            .AddDate(month, DateDisplayType.YearMonth)
                            .Build()
                        .Build();
            }

            _content = listBuilder
                            .Build()
                        .Build()
                    .BuildOne<BlockContent>();
        }
    }


}
