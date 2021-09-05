using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Web
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
