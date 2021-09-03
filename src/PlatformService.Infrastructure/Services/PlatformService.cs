using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories.Abstractions;
using Mapster;

namespace PlatformService.Infrastructure.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IAsyncReadOnlyRepository<Platform> _readOnlyRepository;

        public PlatformService(
            IAsyncReadOnlyRepository<Platform> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        public async Task<IEnumerable<GetPlatformsSuccessModel>> GetAll(CancellationToken cancellationToken)
        {
            return (await _readOnlyRepository
                .All(cancellationToken))
                .Select(platform => platform.Adapt<GetPlatformsSuccessModel>());
        }
    }
}
