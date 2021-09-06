using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web
{
    [ApiController]
    [Route("api/platform/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
