using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
