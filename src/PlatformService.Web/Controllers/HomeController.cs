using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Web.Controllers
{
    public class HomeController : ApiController
    {
        public HomeController()
        {
        }

        // HomeController
        // ONLY FOR TESTING!

        [HttpGet]
        public IActionResult Get()
            => Ok("Work!");
    }
}
