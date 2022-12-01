using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Icon;
using OptionA.Blog.Components.Link;
using OptionA.Blog.Components.List;
using OptionA.Blog.Components.Services;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;

namespace OptionA.Blog.Components.Post
{
    [SupportedOSPlatform("browser")]
    public partial class TableOfContents : IDisposable
    {
        [JSImport("scrollToElement", "TableOfContents")]
        internal static partial void ScrollToElement(string elementId);
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        private BlockContent? _content;
        private string _currentLocation = string.Empty;

        /// <inheritdoc/>
        protected override async Task OnInitializedAsync()
        {
            await JSHost.ImportAsync("TableOfContents", "../_content/OptionA.Blog.Components/Post/TableOfContents.razor.js");
            PostService.PostSelected += PostSelected;
            Navigation.LocationChanged += LocationChanged;
        }

        private void LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            var locations = e.Location
                .Replace(Navigation.BaseUri, string.Empty)
                .Split('#');
            if (locations[0] != _currentLocation)
            {
                BuildPost(null);
            }
            else if (locations.Length > 1)
            {
                ScrollToElement(locations[1]);
            }
        }

        private void PostSelected(object? sender, IPost? e)
        {
            BuildPost(e);
        }

        private void BuildPost(IPost? post)
        {
            if (post is null)
            {
                _content = null;
            }
            else
            {
                _currentLocation = Navigation.Uri.Replace(Navigation.BaseUri, string.Empty);
                var listBuilder = ComponentBuilder
                    .CreateBuilder()
                        .CreateBlock()                           
                            .CreateList()
                                .CreateRow()
                                    .CreateLink()
                                        .WithText(post.Title)
                                        .WithHref($"/{_currentLocation}#{post.TitleId}", LinkMode.Internal)
                                        .WithOnClick((e) => {
                                            ScrollToElement(post.TitleId);
                                            return Task.CompletedTask;
                                            })
                                        .Build()
                                    .Build();

                foreach(var (value, id, size) in post.GetHeaders())
                {
                    var row = listBuilder
                        .CreateRow();
                    
                    if (size > 1)
                    {
                        row.AddPadding(Side.Left, (Strength)(size - 1));
                    }
                    row
                        .CreateLink()
                            .WithText(value)
                            .WithHref($"/{_currentLocation}#{id}", LinkMode.Internal)
                            .WithOnClick((e) => {
                                ScrollToElement(id);
                                return Task.CompletedTask;
                            })
                            .Build()
                        .Build();
                }

                _content = listBuilder
                                .Build()
                            .Build()
                        .BuildOne<BlockContent>();

            }
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing) 
            {
                PostService.PostSelected -= PostSelected;
                Navigation.LocationChanged -= LocationChanged;
            }
        }
    }
}
