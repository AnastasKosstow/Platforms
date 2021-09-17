using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PlatformService.Mediator.Abstractions;

namespace PlatformService.Mediator.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMediator(
            this IServiceCollection services, 
            ServiceLifetime lifetime, 
            params Type[] assemblies)
        {
            var handlerInfo = new Dictionary<Type, Type>();

            //for testing
            var typesRequests = new List<Type>();
            var typesHandlers = new List<Type>();

            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                typesRequests.AddRange(GetClassesImplementingInterface(assembly, typeof(IRequest<>)));
                typesHandlers.AddRange(GetClassesImplementingInterface(assembly, typeof(IHandler<,>)));
            }

            typesRequests.ForEach(type =>
            {
                // IHandler`2
                // GetInterface search for IHandler with two generic arguments
                handlerInfo[type] =
                    typesHandlers.SingleOrDefault(x => type == x.GetInterface("IHandler`2")!
                                                           .GetGenericArguments()[0]);
            });

            var serviceDescriptor = typesHandlers.Select(x => new ServiceDescriptor(x, x, lifetime));
            services.TryAdd(serviceDescriptor);

            services.AddSingleton<IMediator>(serviceProvider => 
                new Mediator(serviceProvider, handlerInfo));

            return services;
        }


        private static IEnumerable<Type> GetClassesImplementingInterface(Assembly assembly, Type interfaceType)
        {
            return assembly.ExportedTypes
                    .Where(type =>
                    {
                        var implementRequestType = type
                            .GetInterfaces()
                            .Any(@interface => @interface.IsGenericType &&
                                               @interface.GetGenericTypeDefinition() == interfaceType);

                        return implementRequestType;
                    });
        }


        public static void ForEach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (var element in list)
                action(element);
        }
    }
}
