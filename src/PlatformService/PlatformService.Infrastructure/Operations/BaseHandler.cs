using PlatformService.Messaging;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure.Operations
{
    public abstract class BaseHandler
    {
        protected readonly IAsyncRepository<Platform> AsyncRepository;
        protected readonly IMessageBusClient MessageBusClient;

        public BaseHandler(IAsyncRepository<Platform> asyncRepository)
            : this(asyncRepository, null)
        {
        }

        public BaseHandler(
            IAsyncRepository<Platform> asyncRepository,
            IMessageBusClient messageBusClient)
        {
            AsyncRepository = asyncRepository;
            MessageBusClient = messageBusClient;
        }
    }
}
