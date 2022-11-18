using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionA.Blog.Components.Post
{
    public partial class ArchiveMonth
    {
        [Inject]
        private PostService PostService { get; set; } = null!;

        [Parameter]
        public DateTime? Month { get; set; }

        private LinkContent? GetPostContent(IPost post)
        {
            return ComponentBuilder
                .CreateBuilder(post)
                .CreateLink()
                    .WithText(post.Title)
                    .WithTitle(post.Subtitle ?? post.Title)
                    .WithHref($"/post/{post.TitleId}")
                    .OpensInNewTab(false)
                    .Build()
                .Build()
                .FirstOrDefault() as LinkContent;
        }
    }
}
