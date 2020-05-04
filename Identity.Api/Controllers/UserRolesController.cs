using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Identity.Contrat.Users.Requests;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public UserRolesController(IMapper mapper, IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public IActionResult GetUserRoles(Guid userId)
        {
            return Ok(_dispatcher.Dispatch(new GetRolesByUserIdQuery(userId)));
        }

        [HttpPatch]
        public IActionResult EditRoles([FromBody] AssignRolesToUserRequest request)
        {
            var command = _mapper.Map<AssignRolesToUserCommad>(request);
            _busPublisher.SendAsync<AssignRolesToUserCommad>(command);
            return Ok(request);
        }
    }
}