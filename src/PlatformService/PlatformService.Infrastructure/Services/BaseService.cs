using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;

namespace PlatformService.Infrastructure.Services
{
    public abstract class BaseService<TEntity>
    {
        protected readonly IAsyncRepository<Platform> _asyncRepository;

        public BaseService(IAsyncRepository<Platform> asyncRepository)
        {
            _asyncRepository = asyncRepository;
        }
    }
}
