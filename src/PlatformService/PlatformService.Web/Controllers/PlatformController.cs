using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;
using PlatformService.Mediator.Abstractions;

namespace PlatformService.Web.Controllers
{
    public class PlatformController : ApiController
    {
        private readonly IMediator _mediator;

        public PlatformController(IMediator mediator)
            =>
            _mediator = mediator;


        [HttpGet]
        public async Task<GetPlatformsSuccessModel> All(
            GetPlatformsRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _mediator.SendAsync(requestModel, cancellationToken);


        [HttpGet]
        public async Task<FindPlatformSuccessModel> Single(
            FindPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _mediator.SendAsync(requestModel, cancellationToken);


        [HttpPost]
        public async Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _mediator.SendAsync(requestModel, cancellationToken);


        [HttpDelete]
        public async Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await _mediator.SendAsync(requestModel, cancellationToken);
    }
}
