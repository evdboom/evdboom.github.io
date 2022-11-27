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
        "oa-margin-bottom-2",
        "oa-margin-right-2",
        "oa-padding-top-1",
        "oa-padding-bottom-1",
        "oa-padding-left-2",
        "oa-padding-right-2");
    DefaultClasses.ArchiveContainer.AddRange(
        "shadowed-box", 
        "padded", 
        "bordered", 
        "roundedborder", 
        "oa-margin-bottom-3");
    DefaultClasses.CompactMode.AddRange(
        "hover", 
        "shadowed-box", 
        "oa-style-none", 
        "bordered", 
        "roundedborder", 
        "oa-margin-bottom-3",
        "padded");
    DefaultClasses.TagContainer.AddRange(
        "shadowed-box", 
        "padded", 
        "bordered", 
        "roundedborder", 
        "oa-margin-bottom-3");
    DefaultClasses.ContainerHeader.AddRange(
        "oa-neg-margin-top-3", 
        "oa-neg-margin-left-3", 
        "oa-borderradius-topleft", 
        "oa-borderradius-bottomright", 
        "bordered", 
        "oa-margin-bottom-3",
        "oa-padding-top-2",
        "oa-padding-bottom-2",
        "oa-padding-left-3",
        "oa-padding-right-3");
    DefaultClasses.CodeBlock.AddRange(
        "lightly-padded",
        "roundedborder");
    DefaultClasses.CodeHeaderBlock.AddRange(
        "lightly-padded",
        "oa-borderradius-topleft",
        "oa-borderradius-topright",
        "oa-margin-bottom-1",
        "oa-neg-margin-left-2",
        "oa-neg-margin-top-2",
        "oa-neg-margin-right-2");
}