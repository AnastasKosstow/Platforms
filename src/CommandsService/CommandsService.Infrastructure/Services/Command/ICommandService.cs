using CommandsService.Application.Models.Get;
using System.Threading;
using System.Threading.Tasks;

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
    }
}
