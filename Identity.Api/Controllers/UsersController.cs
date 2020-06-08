using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Contrat.Users.Requests;
using Identity.Api.Contrat.Users.Responses;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Identity.Services.Users;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly ICommandSender _commandSender;
        private readonly Dispatcher _dispatcher;

        public UsersController(IMapper mapper, LinkGenerator linkGenerator,
                             ICommandSender commandSender, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _commandSender = commandSender;
            _dispatcher = dispatcher;
        }

        [HttpGet()]
        public IActionResult GetUser(Guid userId)
        {
            var user = _dispatcher.Dispatch(new GetUserByIdQuery(userId));
            if (user == null)
                return NotFound("user not found");
            return Ok(user);
        }

        [HttpGet("GetUserInfo")]
        public IActionResult GetUserInfo(Guid userId)
        {
            var user = _dispatcher.Dispatch(new GetUserPermissionsInfoByIdQuery(userId));
            if (user == null)
                return NotFound("user not found");
            return Ok(user);
        }


        [HttpPost()]
        public IActionResult Register([FromBody] RegisterUserRequest registerRequest)
        {
            var command = _mapper.Map<RegisterUserCommand>(registerRequest);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult UnregisterUser([FromBody] UnregisterUserRequest unregisterUserRequest)
        {
            var command = _mapper.Map<UnregisterUserCommand>(unregisterUserRequest);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpPatch]
        public IActionResult EditUser([FromBody] EditUserRequest editUserRequest)
        {
            var command = _mapper.Map<EditUserCommand>(editUserRequest);
            var result = _commandSender.Send(command);
            if (result.IsFailure)
                return BadRequest(result);
            return Ok(result);
        }
    }
}