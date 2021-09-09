using CommandsService.Persistence.Models;
using CommandsService.Persistence.Repositories;

namespace CommandsService.Infrastructure.Services
{
    public class CommandService : BaseService<Command>, ICommandService
    {
        public CommandService(IAsyncRepository<Command> asyncCommandRepository)
            : base(asyncCommandRepository)
        {
        }
    }
}
