using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models.Get;
using PlatformService.Mediator.Abstractions;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using Mapster;

namespace PlatformService.Infrastructure.Operations
{
    public class GetPlatformsHandler : BaseHandler, IHandler<GetPlatformsRequestModel, GetPlatformsSuccessModel>
    {
        public GetPlatformsHandler(IAsyncRepository<Platform> asyncRepository)
            : base(asyncRepository)
        {
        }

        public async Task<GetPlatformsSuccessModel> HandleAsync(
            GetPlatformsRequestModel request,
            CancellationToken cancellationToken)
        {
            IEnumerable<PlatformModel> platforms =
                (await AsyncRepository.All(CancellationToken.None))
                .Select(platform => platform.Adapt<PlatformModel>());

            return new GetPlatformsSuccessModel(platforms);
        }
    }
}
