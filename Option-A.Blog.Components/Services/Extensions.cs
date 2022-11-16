using Microsoft.Extensions.DependencyInjection;

namespace OptionA.Blog.Components.Services
{
    public static class Extensions
    {
        /// <summary>
        /// Adds the following services to the container:
        /// <para><see cref="ServiceLifetime.Scoped"/> <see cref="IClipboardService"/> for copying from the clipboard</para>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services) 
        {
            services
                .AddScoped<IClipboardService, ClipboardService>();

            return services;
        }
    }
}
