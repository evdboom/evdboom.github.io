using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Date;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Line;
using OptionA.Blog.Components.Link;
using System.Drawing;

namespace OptionA.Blog.Components.Post
{
    /// <summary>
    /// Post component
    /// </summary>
    public partial class PostContent
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        private BlockContent? _displayContent;

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

        /// <summary>
        /// SetCorrect content
        /// </summary>
        protected override void OnParametersSet()
        {
            if (Content is null)
            {
                return;
            }

            var builder = ComponentBuilder
                .CreateBuilder(Content);

            if (CompactMode)
            {
                _displayContent = builder
                    .CreateBlock()                        
                        .CreateDate()
                        .ForDate(Content.PostDate)
                        .WithDisplayType(DateDisplayType.LongDate)
                        .WithTextAlignment(PositionType.Right)
                        .WithStyle(Style.Bold)
                        .Build() 
                            
                        .CreateLink()
                            .WithHref($"/post/{Content.TitleId}")
                            .WithTextAlignment(PositionType.Inherit)
                            .AddTags(Content.Tags)
                            .WithTextAlignment(PositionType.Left)
                            .WithBlockAlignment(PositionType.Inherit)
                            .WithBlockType(BlockType.Block)
                            .AddClasses(DefaultClasses.CompactMode)                           
                            .AddHeader(Content.Title, HeaderSize.One)
                            .WithStyle(Style.Italic)
                            .WithColor(BlogColor.Subtle)
                            .AddParagraph(Content.Subtitle)
                            .WithStyle(Style.Inherit)
                            .WithColor(BlogColor.Text)
                            .AddLine()
                            .AddContents(Content.Content)
                            .Build()
                        .Build()
                    .BuildOne<BlockContent>();                
            }
            else
            {
                _displayContent = builder
                    .CreateBlock()                            
                        .WithTextAlignment(PositionType.Center)
                        .AddHeader(Content.Title, HeaderSize.One)
                        .CreateBlock()                            
                            .AddTags(Content.Tags)
                            .WithBlockAlignment(PositionType.Center)
                            .Build()
                        .WithStyle(Style.Italic)
                        .WithColor(BlogColor.Subtle)
                        .AddDate(Content.PostDate, DateDisplayType.LongDate)
                        .WithStyle(Style.Inherit)
                        .AddParagraph(Content.Subtitle)
                        .AddLine()
                        .AddContents(Content.Content)
                        .WithBlockType(BlockType.Content)
                        .Build()
                    .BuildOne<BlockContent>();
            }

        }
    }
}
