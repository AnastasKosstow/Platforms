using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web
{
    [ApiController]
    [Route("api/p/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
