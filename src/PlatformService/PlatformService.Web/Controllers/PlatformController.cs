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
        public PlatformController(IMediator mediator)
            : base(mediator)
        {
        }


        [HttpGet]
        [Route(nameof(All))]
        public async Task<GetPlatformsSuccessModel> All(
            [FromQuery]GetPlatformsRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await Mediator.SendAsync(requestModel, cancellationToken);


        [HttpGet]
        [Route(nameof(Single))]
        public async Task<FindPlatformSuccessModel> Single(
            FindPlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await Mediator.SendAsync(requestModel, cancellationToken);


        [HttpPost]
        [Route(nameof(Create))]
        public async Task<CreatePlatformSuccessModel> Create(
            CreatePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await Mediator.SendAsync(requestModel, cancellationToken);


        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<DeletePlatformSuccessModel> Delete(
            DeletePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
            =>
            await Mediator.SendAsync(requestModel, cancellationToken);
    }
}
