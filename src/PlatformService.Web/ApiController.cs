using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
