using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Identity.Contrat.Roles.Requests;
using Identity.Api.Identity.Domain.RoleFeatures.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleFeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public RoleFeaturesController(IMapper mapper, LinkGenerator linkGenerator,
                             IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }


        [HttpGet]
        public IActionResult GetRoleFeature(Guid roleId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Edit([FromBody] EditRoleFeaturesRequest request)
        {
            var command = _mapper.Map<EditRoleFeaturesCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPost("AssignFeature")]
        public IActionResult AssignFeature([FromBody] string roles)
        {
            throw new NotImplementedException();
        }

        [HttpPost("DismissFeature")]
        public IActionResult DismissFeature([FromBody] string roles)
        {
            throw new NotImplementedException();
        }
    }
}