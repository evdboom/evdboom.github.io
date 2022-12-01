using Blog;
using Blog.Responsive;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OptionA.Blog.Components;
using OptionA.Blog.Components.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

ConfigureServices(builder.Services, builder.HostEnvironment.BaseAddress);

await builder.Build().RunAsync();

static void ConfigureServices(IServiceCollection services, string baseAddress)
{
    services
        .AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) })
        .AddBlogServices()
        .AddSingleton<IResponsiveService, ResponsiveService>();
    
    DefaultClasses.Tag.AddRange(
        "hover", 
        "oa-style-none",
        "oa-padding-y-1",
        "oa-padding-x-2");
    DefaultClasses.CompactMode.AddRange(
        "hover", 
        "shadowed-box", 
        "oa-style-none", 
        "oa-border", 
        "oa-borderradius",
        "oa-padding-3");
    DefaultClasses.Container.AddRange(
        "shadowed-box",
        "oa-border",
        "oa-borderradius",
        "oa-padding-3");
    DefaultClasses.ContainerHeaderName.AddRange(
        "oa-neg-margin-top-3",
        "oa-neg-margin-left-3",
        "oa-padding-y-2",
        "oa-padding-x-3",
        "oa-borderradius-topleft",
        "oa-borderradius-bottomright");
    DefaultClasses.ContainerHideButton.AddRange(
        "pointer");
    DefaultClasses.CodeBlock.AddRange(
        "lightly-padded",
        "roundedborder");
    DefaultClasses.CodeHeaderBlock.AddRange(
        "lightly-padded",
        "oa-borderradius-topleft",
        "oa-borderradius-topright",
        "oa-neg-margin-x-2",
        "oa-neg-margin-top-2");
}