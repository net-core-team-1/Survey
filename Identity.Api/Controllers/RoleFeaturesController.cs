using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Roles.Requests;
using Identity.Api.Contrats.Roles.Requests;
using Identity.Api.Identity.Domain.Roles.Commands;
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
        public IActionResult Edit([FromBody] EditRoleFeatureRequest request)
        {
            var command = _mapper.Map<EditRoleFeatureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult AssignFeature([FromBody] RegisterRoleFeatureRequest request)
        {
            var command = _mapper.Map<RegisterRoleFeatureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpDelete]
        public IActionResult RemoveFeature([FromBody] UnregisterRoleFeatureRequest request)
        {
            var command = _mapper.Map<UnregisterRoleFeatureCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }
    }
}