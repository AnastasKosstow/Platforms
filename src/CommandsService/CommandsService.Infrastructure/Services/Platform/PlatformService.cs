using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommandsService.Application.Models.Get;
using CommandsService.Persistence.Models;
using CommandsService.Persistence.Repositories;
using Mapster;

namespace CommandsService.Infrastructure.Services
{
    public class PlatformService : BaseService<Platform>, IPlatformService
    {
        public PlatformService(IAsyncRepository<Platform> asyncPlatformRepository)
            : base(asyncPlatformRepository)
        {
        }

        public async Task<GetAllPlatformsSuccessModel> GetAll(CancellationToken cancellationToken)
        {
            IEnumerable<PlatformModel> platforms =
                (await _asyncRepository.GetAll(cancellationToken))
                .Select(platform => platform.Adapt<PlatformModel>());

            return new GetAllPlatformsSuccessModel(platforms);
        }

        public async Task<bool> ExternalPlatformExist(int externalPlatformId, CancellationToken cancellationToken)
        {
            return (await _asyncRepository.GetAll(cancellationToken))
                .Any(x => x.Id == externalPlatformId);
        }
    }
}
