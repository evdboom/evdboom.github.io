using Microsoft.AspNetCore.Components;
using OptionA.Blog.Components.Core.Enums;
using OptionA.Blog.Components.Core;
using OptionA.Blog.Components.Image;
using OptionA.Blog.Components.Link;
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

        public static Parent AddNavMenuItem<Parent>(this Parent parent, string href, string description) where Parent : IParentBuilder
        {
            return parent
                .CreateLink()
                    .WithColor(BlogColor.Inherit)
                    .WithHref(href)
                    .WithMode(LinkMode.Self)
                    .WithText(description)
                    .WithTitle(description)
                    .AddClasses("nav-item", "fs-3", "hover")
                    .Build();
        }
    }
}
