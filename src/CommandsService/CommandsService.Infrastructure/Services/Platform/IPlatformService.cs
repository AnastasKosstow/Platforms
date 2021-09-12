using CommandsService.Application.Models.Get;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsService.Infrastructure.Services
{
    public interface IPlatformService
    {
        Task<GetAllPlatformsSuccessModel> GetAll(CancellationToken cancellationToken);
        Task<bool> ExternalPlatformExist(int externalPlatformId, CancellationToken cancellationToken);
    }
}
