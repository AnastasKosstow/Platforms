﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommandsService.Persistence;
using CommandsService.Persistence.Models;
using CommandsService.Persistence.Repositories;
using CommandsService.Infrastructure.Services;

namespace CommandsService.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            return services
                .AddDatabase(configuration)
                .AddServices()
                .AddRepository();
        }


        private static IServiceCollection AddDatabase(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => 
                    options.UseSqlServer(configuration.GetConnectionString("LocalConnection")));

            return services;
        }


        private static IServiceCollection AddServices(
            this IServiceCollection services)
        {
            return services
                .AddScoped<ICommandService, CommandService>()
                .AddScoped<IPlatformService, PlatformService>();
        }


        private static IServiceCollection AddRepository(
            this IServiceCollection services)
        {
            return services
                .AddScoped<IAsyncRepository<Command>, AsyncRepository<Command>>()
                .AddScoped<IAsyncRepository<Platform>, AsyncRepository<Platform>>();
        }
    }
}