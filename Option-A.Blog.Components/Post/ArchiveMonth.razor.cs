using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Services;

namespace OptionA.Blog.Components.Post
{
    public partial class ArchiveMonth
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;

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

        private LinkContent? GetPostContent(IPost post)
        {
            return ComponentBuilder
                .CreateBuilder(post)
                .CreateLink()
                    .WithText($"{DateDisplayType.Date.ToDateFormat(post.PostDate)} - {post.Title}")
                    .WithTitle(post.Subtitle ?? post.Title)
                    .WithHref($"/post/{post.TitleId}")
                    .OpensInNewTab(false)
                    .Build()
                .BuildOne<LinkContent>();
        }
    }
}
