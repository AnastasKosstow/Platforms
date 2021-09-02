using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace PlatformService.Web.Controllers
{
    public class HomeController : ApiController
    {
        // HomeController
        // ONLY FOR TESTING!

        [HttpGet]
        public async Task<IActionResult> TEST()
        {
            return Ok();
        }
    }
}
