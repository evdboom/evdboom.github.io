using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Web;

namespace Blog.Components
{
    public partial class SearchComponent
    {
        [Inject]
        private NavigationManager Navigation { get; set; } = null!;
        
        private string? SearchTerm { get; set; }

        private void KeyPress(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                Search();
            }
        }

        private void Search()
        {
            var term = HttpUtility.UrlEncode(SearchTerm);
            Navigation.NavigateTo($"/search?term={term}");
        }
    }
}
