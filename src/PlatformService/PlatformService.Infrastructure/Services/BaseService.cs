using PlatformService.Messaging;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure.Services
{
    public abstract class BaseService<TEntity>
    {
        protected readonly IAsyncRepository<Platform> _asyncRepository;
        protected readonly ICommandDataClient _commandDataClient;

        public BaseService(
            IAsyncRepository<Platform> asyncRepository,
            ICommandDataClient commandDataClient)
        {
            _asyncRepository = asyncRepository;
            _commandDataClient = commandDataClient;
        }
    }
}
