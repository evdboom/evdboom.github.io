using Blog;
using Blog.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OptionA.Blazor.Blog;
using OptionA.Blazor.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services
        .AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) })
        .AddScoped<IPostClient, PostClient>()
        .AddOptionABlog(options =>
        {
            options.PostTitleClass = "opta-header text-center";
            options.HeaderTagContainerClass = "text-center";
            options.PostDateClass = "text-center italic";
            options.PostSubtitleClass = "text-center";
            options.TagClass = "opta-tag";
        })
        .AddOptionAComponents(options =>
        {
            options.MenuConfiguration = menu =>
            {
                menu.OpenGroupOnMouseOver = true;
                menu.GroupCloseTime = 250;
                menu.DefaultMenuContainerClass += " nav-menu";
                menu.DefaultDropdownClass = "opta-bg opta-dropdown";
                menu.DefaultMenuItemClass += " opta-menu-item";
                menu.ActiveClass = "active";                
            };
        });
}