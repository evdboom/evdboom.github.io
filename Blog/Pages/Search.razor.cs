using Blog.Navigation;
using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Block;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Header;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Search : IDisposable
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        private string? _term;
        private HeaderContent? _content;

        protected override void OnInitialized()
        {
            _content = ComponentBuilder
                .CreateBuilder()
                .CreateHeader()
                    .WithTextAlignment(PositionType.Center)
                    .WithText("Found these posts for: ")
                    .Build()
                .BuildOne<HeaderContent>();
            SetTerm();
            Navigation.LocationChanged += LocationChanged;
        }

        private void LocationChanged(object? sender, Microsoft.AspNetCore.Components.Routing.LocationChangedEventArgs e)
        {
            SetTerm();
        }

        private void SetTerm()
        {
            var parameters = Navigation.GetQueryParameters();
            _term = parameters.TryGetValue("term", out string? value)
                ? value
                : "No term found";
            StateHasChanged();
        }

        void IDisposable.Dispose()
        {
            Navigation.LocationChanged -= LocationChanged;
        }

    }
}
