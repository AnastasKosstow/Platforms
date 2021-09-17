using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;
using PlatformService.Infrastructure.Services;
using PlatformService.Mediator.Abstractions;

namespace PlatformService.Web.Controllers
{
    public class PlatformController : ApiController
    {
        private readonly IPlatformService _platformService;
        private readonly IMediator _mediator;

        public PlatformController(IPlatformService platformService, IMediator mediator)
        {
            _mediator = mediator;
            _platformService = platformService;
        }
        

        [HttpGet]
        public async Task<GetPlatformsSuccessModel> GetPlatforms(
            CancellationToken cancellationToken)
            =>
            await _mediator.SendAsync(new GetPlatformsRequestModel());
            // await _platformService.Get(cancellationToken);


        [HttpPost]
        public async Task<CreatePlatformSuccessModel> CreatePlatform(
            CreatePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            => 
            await _platformService.Create(requestModel, cancellationToken);


        [HttpDelete]
        public async Task<DeletePlatformSuccessModel> DeletePlatform(
            DeletePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            => 
            await _platformService.Delete(requestModel, cancellationToken);
    }
}
