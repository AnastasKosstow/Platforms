using System.Threading;
using System.Threading.Tasks;
using CommandsService.Application.Models.Get;
using CommandsService.Application.Models.Post;

namespace CommandsService.Infrastructure.Services
{
    public interface ICommandService
    {
        Task<GetAllPlatformCommandsSuccessModel> GetAll(
            GetAllPlatformCommandsRequestModel requestModel,
            CancellationToken cancellationToken);

        Task<GetCommandForPlatformSuccessModel> GetSingle(
            GetCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken);

        Task<CreateCommandForPlatformSuccessModel> Create(
            CreateCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken);
    }
}
