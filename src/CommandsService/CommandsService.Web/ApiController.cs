using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Web
{
    [ApiController]
    [Route("api/command/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
