
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Web.Controllers
{
    public class PlatformsController : ApiController
    {
        public PlatformsController()
        {
        }

        public IActionResult TestInboundConnection()
        {
            System.Console.WriteLine("--> Inbound POST # Command Service");
            return Ok();
        }
    }
}
