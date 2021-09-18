using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Mediator.DependencyInjection;
using PlatformService.Messaging;
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
                .AddRepository()
                .AddServiceBus()
                .AddMediatorImpl();
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


        private static IServiceCollection AddRepository(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncRepository<Platform>, AsyncRepository<Platform>>();
        }


        private static IServiceCollection AddServiceBus(
            this IServiceCollection services)
        {
            return services
                .AddSingleton<IMessageBusClient, MessageBusClient>();
        }
        
        
        private static IServiceCollection AddMediatorImpl(
            this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                       .Where(assembly => assembly.FullName.Contains("PlatformService"))
                       .ToArray();

            return services
                .AddMediator(config => config.AsSingleton(), assemblies);
        }
    }
}
