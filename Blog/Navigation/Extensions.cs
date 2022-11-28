using Microsoft.AspNetCore.Components;
using System.Web;

namespace Blog.Navigation
{
    public static class Extensions
    {
        public static IDictionary<string, string> GetQueryParameters(this NavigationManager navigation)
        {
            var uri = navigation.ToAbsoluteUri(navigation.Uri);
            if (string.IsNullOrEmpty(uri.Query))
            {
                return new Dictionary<string, string>();
            }

            var query = uri.Query[1..];
            var parts = query.Split('&');

            return parts
                .Select(p => p.Split('='))
                .ToDictionary(i => i[0], i => HttpUtility.UrlDecode(i[1]));
        }
    }
}
