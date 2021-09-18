using Microsoft.AspNetCore.Mvc;
using PlatformService.Mediator.Abstractions;

namespace PlatformService.Web
{
    [ApiController]
    [Route("api/p/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected readonly IMediator Mediator;

        protected ApiController(IMediator mediator)
            =>
            Mediator = mediator;
    }
}
