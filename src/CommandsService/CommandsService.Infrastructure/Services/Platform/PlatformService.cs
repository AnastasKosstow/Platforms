using CommandsService.Persistence.Models;
using CommandsService.Persistence.Repositories;

namespace CommandsService.Infrastructure.Services
{
    public class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(IAsyncRepository<Platform> asyncPlatformRepository)
            : base(asyncPlatformRepository)
        {
        }
    }
}
