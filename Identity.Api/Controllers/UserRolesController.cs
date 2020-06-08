using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Users.Requests;
using Identity.Api.Contrats.Users.Requests;
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
        private readonly ICommandSender _commandSender;
        private readonly Dispatcher _dispatcher;

        public UserRolesController(IMapper mapper, ICommandSender commandSender, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _dispatcher = dispatcher;
        }

        [HttpGet]
        public IActionResult GetUserRoles(Guid userId)
        {
            return Ok(_dispatcher.Dispatch(new GetRolesByUserIdQuery(userId)));
        }

        [HttpPost]
        public IActionResult EditRoles([FromBody] EditUserRolesRequest request)
        {
            var command = _mapper.Map<EditUserRolesCommad>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult AssignUserRole([FromBody] RegisterUserRoleRequest request)
        {
            var command = _mapper.Map<RegisterUserRoleCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult RemoveUserRole([FromBody] UnregisterUserRoleRequest request)
        {
            var command = _mapper.Map<UnregisterUserRoleCommand>(request);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}