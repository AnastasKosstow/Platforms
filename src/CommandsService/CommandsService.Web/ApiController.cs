using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Web
{
    [ApiController]
    [Route("api/c/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
