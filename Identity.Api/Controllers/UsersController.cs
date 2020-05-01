using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common.Types.Types.ServiceBus;
using Identity.Api.Identity.Contrat.Users.Requests;
using Identity.Api.Identity.Domain.Users.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
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

        public UsersController(
            IMapper mapper,
            LinkGenerator linkGenerator,
            IUserService userService,
            IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
        }

        [HttpGet()]
        public IActionResult Index()
        {
            return Ok("identity Service");
        }

        [HttpPost()]
        public IActionResult Register([FromBody] RegisterUserRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
            _busPublisher.SendAsync(registerCommand);
            return Ok();
        }
    }
}