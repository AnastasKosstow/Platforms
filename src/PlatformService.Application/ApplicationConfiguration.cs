using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Messaging.Configuration;

namespace PlatformService.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<RabbitMqConfiguration>(
                    configuration.GetSection(nameof(RabbitMqConfiguration)),
                    options => options.BindNonPublicProperties = false);

            return services;
        }
    }
}
