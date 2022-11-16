using Microsoft.Extensions.DependencyInjection;

namespace OptionA.Blog.Components.Services
{
    /// <summary>
    /// Extensions to add the services to the service collection
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Adds the following services to the container:
        /// <para><see cref="ServiceLifetime.Scoped"/> <see cref="IClipboardService"/> for copying from the clipboard</para>
        /// <para><see cref="ServiceLifetime.Scoped"/> <see cref="IPostService"/> for finding and enumerating posts</para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddBlogServices(this IServiceCollection services) 
        {
            services
                .AddScoped<IClipboardService, ClipboardService>()
                .AddScoped<IPostService, PostService>();

            return services;
        }
    }
}
