using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Identity.Contrat.Roles.Requests;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public RolesController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet("GetRoleById")]
        public IActionResult GetRoleById(Guid roleId)
        {
            return Ok(_dispatcher.Dispatch(new GetRoleByIdQuery(roleId)));
        }

        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            return Ok(_dispatcher.Dispatch(new GetAllRolesQuery()));
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterRoleRequest request)
        {
            var command = _mapper.Map<RegisterRoleCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] EditRoleRequest request)
        {
            var command = _mapper.Map<EditRoleCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpDelete]
        public IActionResult Unregister([FromBody] UnregisterRoleRequest request)
        {
            var command = _mapper.Map<UnregisterRoleCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }

        [HttpPatch]
        public IActionResult Disable([FromBody] DisableRoleRequest request)
        {
            var command = _mapper.Map<DisableRoleCommand>(request);
            _busPublisher.SendAsync(command);
            return Ok(request);
        }
    }
}