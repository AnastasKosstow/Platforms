using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Infrastructure.Services;
using PlatformService.Persistence;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories.Abstractions;
using PlatformService.Persistence.Repositories.Repositories;
using PlatformService.Persistence.UnitOfWork;

namespace PlatformService.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDatabase(configuration)
                .AddServices()
                .AddUnitOfWork()
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


        private static IServiceCollection AddUnitOfWork(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncUnitOfWork<ApplicationDbContext>, AsyncUnitOfWork<ApplicationDbContext>>();
        }


        private static IServiceCollection AddRepositories(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncReadOnlyRepository<Platform>, AsyncReadOnlyRepository<Platform>>()
                .AddScoped<IDeletionRepository<Platform>, DeletionRepository<Platform>>()
                .AddScoped<IInsertionRepository<Platform>, InsertionRepository<Platform>>();
        }
    }
}
