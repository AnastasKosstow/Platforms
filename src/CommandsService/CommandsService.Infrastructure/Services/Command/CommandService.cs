using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CommandsService.Application.Models.Get;
using CommandsService.Application.Models.Post;
using CommandsService.Infrastructure.Exceptions;
using CommandsService.Infrastructure.Validation;
using CommandsService.Persistence.Models;
using CommandsService.Persistence.Repositories;
using Mapster;

namespace CommandsService.Infrastructure.Services
{
    public class CommandService : BaseService<Command>, ICommandService
    {
        public CommandService(IAsyncRepository<Command> asyncCommandRepository)
            : base(asyncCommandRepository)
        {
        }


        public async Task<GetAllPlatformCommandsSuccessModel> GetAll(
            GetAllPlatformCommandsRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            IEnumerable<Command> commands =
                await _asyncRepository.GetAll(
                    x => x.PlatformId == requestModel.PlatformId,
                    cancellationToken);

            Guard.AgainstNullOrEmpty<IEnumerable<Command>, MissingItemsException>(commands);

            IEnumerable<CommandModel> commandModels = 
                commands.Select(platform => platform.Adapt<CommandModel>());

            return new GetAllPlatformCommandsSuccessModel(commandModels);
        }


        public async Task<GetCommandForPlatformSuccessModel> GetSingle(
            GetCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            Command command =
                await _asyncRepository.GetSingle(
                    x => x.PlatformId == requestModel.PlatformId,
                    cancellationToken);

            Guard.AgainstNullOrEmpty<Command, MissingItemsException>(command);

            return command.Adapt<GetCommandForPlatformSuccessModel>();
        }


        public async Task<CreateCommandForPlatformSuccessModel> Create(
            CreateCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            Command command = requestModel.Adapt<Command>();

            Guard.AgainstNullOrEmpty<Command, MissingItemsException>(command);

            _asyncRepository.Create(command);
            await _asyncRepository.CompleteAsync(cancellationToken);

            return await Task.FromResult(
                    new CreateCommandForPlatformSuccessModel(command)
                ); 
        }
    }
}
