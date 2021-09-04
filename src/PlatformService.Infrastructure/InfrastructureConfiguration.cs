using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Infrastructure.Services;
using PlatformService.Persistence;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using PlatformService.Persistence.Repositories.Abstractions;

namespace PlatformService.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDatabase(configuration)
                .AddServices()
                .AddRepositories();
        }


        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => 
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }


        private static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IPlatformService, Services.PlatformService>();
        }


        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncRepository<Platform>, AsyncRepository<Platform>>();
        }
    }
}
