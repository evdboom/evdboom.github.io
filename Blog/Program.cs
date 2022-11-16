using Blog;
using Blog.Responsive;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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
}