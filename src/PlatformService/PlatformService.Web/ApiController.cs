using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web
{
    [ApiController]
    [Route("api/p/[controller]/[action]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
