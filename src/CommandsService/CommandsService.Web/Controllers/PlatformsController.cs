using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommandsService.Application.Models.Get;
using CommandsService.Infrastructure.Services;

namespace CommandsService.Web.Controllers
{
    public class PlatformsController : ApiController
    {
        private readonly IPlatformService _platformService;

        public PlatformsController(IPlatformService platformService)
            =>
            _platformService = platformService;
        

        [HttpGet]
        public async Task<GetAllPlatformsSuccessModel> GetAll(CancellationToken cancellationToken)
            =>
            await _platformService.GetAll(cancellationToken);
    }
}
