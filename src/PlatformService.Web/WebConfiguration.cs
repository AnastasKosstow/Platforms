using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Web.Filters;

namespace PlatformService.Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWebComponents(this IServiceCollection services)
        {
            services
                .AddControllers(options =>
                {
                    options.Filters.Add<ExceptionHandlingFilter>();
                });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                //
            });

            return services;
        }
    }
}
