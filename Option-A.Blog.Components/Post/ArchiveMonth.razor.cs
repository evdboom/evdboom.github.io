using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// Archive component for a specific month
    /// </summary>
    public partial class ArchiveMonth
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

        /// <summary>
        /// Month for which there is content
        /// </summary>
        [Parameter]
        public DateTime? Month { get; set; }

        private bool _isOpen;

        private void SwitchOpenState()
        {
            _isOpen = !_isOpen;
            StateHasChanged();
        }

        private string? GetClasses()
        {
            return _isOpen && DefaultClasses.ListStyleClasses.TryGetValue(ListStyle.DisclosureOpen, out string? classes)
                ? classes
                : string.Empty;
        }

        private string? GetPostItemClasses()
        {
            return DefaultClasses.ListStyleClasses.TryGetValue(ListStyle.None, out string? classes)
                ? classes
                : string.Empty;
        }

        private ListItemContent? GetListItem()
        {
            if (Month is null)
            {
                return null;
            }

            return ComponentBuilder
                .CreateBuilder(null)
                .CreateList()
                    .CreateRow()
                        .WithOnClick((e) =>
                        {
                            SwitchOpenState();
                            return Task.CompletedTask;
                        })
                        .CreateDate()
                            .WithBlockType(Core.Enums.BlockType.Content)
                            .ForDate(Month.Value)
                            .WithDisplayType(DateDisplayType.YearMonth)
                            .Build()
                        .Build()
                    .Build()
                .BuildOne<ListContent>()?
                .ChildContent
                .FirstOrDefault() as ListItemContent;
        }

        private LinkContent? GetPostContent(IPost post)
        {
            return ComponentBuilder
                .CreateBuilder(post)
                    .CreateLink()
                        .WithText($"{DateDisplayType.Date.ToDateFormat(post.PostDate)} - {post.Title}")
                        .WithTitle(post.Subtitle ?? post.Title)
                        .WithHref($"/post/{post.TitleId}")
                        .Build()
                    .BuildOne<LinkContent>();
        }
    }
}
