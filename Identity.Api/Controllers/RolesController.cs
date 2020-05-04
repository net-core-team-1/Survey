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
    public class RolesController : ControllerBase
    {
        [HttpGet()]
        public IActionResult GetRoles(Guid featureId)
        {
            throw new NotImplementedException();
        }

        [HttpPost()]
        public IActionResult Register([FromBody] string featureRequest)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] string unregisterUserRequest)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] string editUserRequest)
        {
            throw new NotImplementedException();
        }
    }
}