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
        private readonly IBusPublisher _busPublisher;
        private readonly Dispatcher _dispatcher;

        public UsersController(IMapper mapper, LinkGenerator linkGenerator,
                             IBusPublisher busPublisher, Dispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
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

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterUserRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
            _busPublisher.SendAsync(registerCommand);
            return Ok();
        }

        [HttpDelete]
        public IActionResult UnregisterUser([FromBody] UnregisterUserRequest unregisterUserRequest)
        {
            var unregisterUserCommand = _mapper.Map<UnregisterUserCommand>(unregisterUserRequest);
            _busPublisher.SendAsync(unregisterUserCommand);
            return Ok();
        }

        [HttpPatch]
        public IActionResult EditUser([FromBody] EditUserRequest editUserRequest)
        {
            var editUserCommand = _mapper.Map<EditUserCommand>(editUserRequest);
            _busPublisher.SendAsync(editUserCommand);
            return Ok();
        }
    }
}