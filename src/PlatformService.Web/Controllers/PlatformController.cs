using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Application.Models.Delete;
using PlatformService.Application.Models.Get;
using PlatformService.Application.Models.Post;
using PlatformService.Application.Models.Put;
using PlatformService.Infrastructure.Services;

namespace PlatformService.Web.Controllers
{
    public class PlatformController : ApiController
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
            => 
            _platformService = platformService;
        

        [HttpGet]
        public async Task<GetPlatformsSuccessModel> GetPlatforms(
            CancellationToken cancellationToken)
        {
            return await _platformService.Get(cancellationToken);
        }


        [HttpPost]
        public async Task<CreatePlatformSuccessModel> CreatePlatform(
            CreatePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            return await _platformService.Create(requestModel, cancellationToken);
        }


        [HttpPut]
        public async Task<UpdatePlatformSuccessModel> UpdatePlatform(
            UpdatePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            return await _platformService.Update(requestModel, cancellationToken);
        }


        [HttpDelete]
        public async Task<DeletePlatformSuccessModel> DeletePlatform(
            DeletePlatformRequestModel requestModel,
            CancellationToken cancellationToken)
        {
            return await _platformService.Delete(requestModel, cancellationToken);
        }
    }
}
