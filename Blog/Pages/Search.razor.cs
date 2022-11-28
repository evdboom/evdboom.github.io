using Blog.Navigation;
using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Services;

namespace Blog.Pages
{
    public partial class Search
    {
        [Inject]
        private IPostService PostService { get; set; } = null!;
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;

        private string? _term;

        protected override void OnParametersSet()
        {            
            var parameters = Navigation.GetQueryParameters();
            _term = parameters.TryGetValue("term", out string? value)
                ? value
                : "No term found";
            

                
        }

    }
}
