using Microsoft.AspNetCore.Mvc;

namespace Survey.Identity.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Content("Identity service is online");
        }


    }
}
