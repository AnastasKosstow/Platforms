using PlatformService.Application.Models;
using PlatformService.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PlatformService.Web.Controllers
{
    public class PlatformController : ApiController
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
            => 
            _platformService = platformService;
        


        public async Task<IEnumerable<GetPlatformsSuccessModel>> GetPlatforms(CancellationToken cancellationToken)
        {
            return await _platformService.GetAll(cancellationToken);
        }
    }
}
