using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommandsService.Application.Models.Get;
using CommandsService.Application.Models.Post;
using CommandsService.Infrastructure.Services;

namespace CommandsService.Web.Controllers
{
    public class CommandsController : ApiController
    {
        private readonly ICommandService _commandService;

        public CommandsController(ICommandService commandService)
            =>
            _commandService = commandService;


        [HttpGet]
        public async Task<GetAllPlatformCommandsSuccessModel> GetAll(
            GetAllPlatformCommandsRequestModel requestModel, 
            CancellationToken cancellationToken)
            =>
            await _commandService.GetAll(requestModel, cancellationToken);


        [HttpGet("GetSingle")]
        public async Task<GetCommandForPlatformSuccessModel> GetSingle(
            GetCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _commandService.GetSingle(requestModel, cancellationToken);


        [HttpPost]
        public async Task<CreateCommandForPlatformSuccessModel> Create(
            CreateCommandForPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _commandService.Create(requestModel, cancellationToken);
    }
}
