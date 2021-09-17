using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure.Operations
{
    public abstract class BaseHandler
    {
        protected readonly IAsyncRepository<Platform> AsyncRepository;

        public BaseHandler(
            IAsyncRepository<Platform> asyncRepository)
        {
            AsyncRepository = asyncRepository;
        }
    }
}
