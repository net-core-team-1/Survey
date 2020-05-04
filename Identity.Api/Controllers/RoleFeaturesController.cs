using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleFeaturesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRoleFeature(Guid roleId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult AssignFeature([FromBody] string roles)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult DismissFeature([FromBody] string roles)
        {
            throw new NotImplementedException();
        }
    }
}