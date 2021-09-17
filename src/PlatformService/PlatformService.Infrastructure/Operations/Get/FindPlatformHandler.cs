using Mapster;
using PlatformService.Application.Models.Common;
using PlatformService.Application.Models.Get;
using PlatformService.Mediator.Abstractions;
using PlatformService.Persistence.Models;
using PlatformService.Persistence.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Infrastructure.Operations.Get
{
    public class FindPlatformHandler : BaseHandler, IHandler<FindPlatformRequestModel, FindPlatformSuccessModel>
    {
        public FindPlatformHandler(IAsyncRepository<Platform> asyncRepository)
            : base(asyncRepository)
        {
        }

        public async Task<FindPlatformSuccessModel> HandleAsync(
            FindPlatformRequestModel request,
            CancellationToken cancellationToken)
        {
            PlatformModel platform =
                (await AsyncRepository.SingleAsync(
                    x => x.Id == request.Id,
                    CancellationToken.None))
                .Adapt<PlatformModel>();

            return new FindPlatformSuccessModel(platform);
        }
    }
}
