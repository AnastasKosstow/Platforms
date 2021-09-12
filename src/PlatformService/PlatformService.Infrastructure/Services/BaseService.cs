using PlatformService.Messaging;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure.Services
{
    public abstract class BaseService<TEntity>
    {
        protected readonly IAsyncRepository<Platform> AsyncRepository;
        protected readonly IMessageBusClient MessageBusClient;

        public BaseService(
            IAsyncRepository<Platform> asyncRepository,
            IMessageBusClient messageBusClient)
        {
            AsyncRepository = asyncRepository;
            MessageBusClient = messageBusClient;
        }
    }
}
