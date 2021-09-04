using System.Threading;
using System.Threading.Tasks;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;

namespace PlatformService.Infrastructure.Services
{
    public interface IPlatformService
    {
        Task<GetPlatformsSuccessModel> Get(
            CancellationToken cancellationToken);

        Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel, 
            CancellationToken cancellationToken);

        Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel, 
            CancellationToken cancellationToken);
    }
}
