using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Infrastructure.Services;
using PlatformService.Messaging;
using PlatformService.Messaging.Http;
using PlatformService.Persistence;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration, 
            bool isProduction)
        {
            return services
                .AddDatabase(configuration, isProduction)
                .AddServices()
                .AddRepository()
                .AddHttpClient();
        }


        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration,
            bool isProduction)
        {
            string connectionString = (isProduction)
                ? connectionString = configuration.GetConnectionString("KubernetesConnection")
                : connectionString = configuration.GetConnectionString("LocalConnection");

            services.AddDbContext<ApplicationDbContext>(
                options => 
                    options.UseSqlServer(connectionString));

            return services;
        }


        private static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IPlatformService, Services.PlatformService>();
        }


        private static IServiceCollection AddRepository(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncRepository<Platform>, AsyncRepository<Platform>>();
        }

        private static IServiceCollection AddHttpClient(
            this IServiceCollection services)
        {
            services.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

            return services;
        }
    }
}
