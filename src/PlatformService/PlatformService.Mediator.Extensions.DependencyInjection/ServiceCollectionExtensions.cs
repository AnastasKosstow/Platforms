using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PlatformService.Mediator.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(this IServiceCollection services, params Assembly[] assemblies)
        {
            return services.AddMediator(assemblies, configuration: null);
        }


        public static IServiceCollection AddMediator(this IServiceCollection services, Action<MediatorServiceConfiguration> configuration, params Assembly[] assemblies)
        {
            return services.AddMediator(assemblies, configuration);
        }


        public static IServiceCollection AddMediator(this IServiceCollection services, IEnumerable<Assembly> assemblies, Action<MediatorServiceConfiguration> configuration)
        {
            if (!assemblies.Any())
            {
                throw new ArgumentException("No assemblies found to scan. Supply at least one assembly to scan for handlers.");
            }

            var serviceConfig = new MediatorServiceConfiguration();

            configuration?.Invoke(serviceConfig);

            //ServiceRegistrar.AddRequiredServices(services, serviceConfig);

            //ServiceRegistrar.AddMediatRClasses(services, assemblies);

            return services;
        }
    }
}
