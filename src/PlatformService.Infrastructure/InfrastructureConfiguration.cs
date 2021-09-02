using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Persistence;

namespace PlatformService.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddDatabase(configuration)
                .AddServices();
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
            // ...

            return services;
        }
    }
}
