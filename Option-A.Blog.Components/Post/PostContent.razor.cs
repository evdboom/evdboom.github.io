using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Header;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// Post component
    /// </summary>
    public partial class PostContent
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        /// <summary>
        /// Content for this post
        /// </summary>
        [Parameter]
        public IPost? Content { get; set; }
        /// <summary>
        /// Gets or sets whether to display content in a compact wat (for displaying in a list)
        /// </summary>
        [Parameter]
        public bool CompactMode { get; set; }

        private void SelectPost()
        {
            Navigation.NavigateTo($"post/{Content?.TitleId}");
        }

        private DateContent? GetDateContent(PositionType textAlignment, Style style, BlogColor color)
        {
            if (Content is null)
            {
                return null;
            }

            return ComponentBuilder
                .CreateBuilder(Content)
                .WithTextAlignment(textAlignment)
                .WithStyle(style)
                .WithColor(color)
                .AddDate(Content.PostDate, DateDisplayType.LongDate)
                .BuildOne<DateContent>();                
        }

        private HeaderContent? GetHeaderContent(PositionType textAlignment)
        {
            if (Content is null)
            {
                return null;
            }

            return ComponentBuilder
                .CreateBuilder(Content)
                .WithTextAlignment(textAlignment)
                .AddHeader(Content.Title, HeaderSize.One)
                .BuildOne<HeaderContent>();                
        }

        private BlockContent? GetSubtitleContent(PositionType textAlignment)
        {
            if (string.IsNullOrEmpty(Content?.Subtitle))
            {
                return null;
            }

            return ComponentBuilder
                .CreateBuilder(Content)
                .WithTextAlignment(textAlignment)
                .WithStyle(Style.Italic)
                .WithColor(BlogColor.Subtle)
                .AddParagraph(Content.Subtitle)
                .BuildOne<BlockContent>();                
        }        

        private string? GetCompactModeClasses()
        {
            return string.Join(' ', DefaultClasses.CompactMode);
        }
    }
}
