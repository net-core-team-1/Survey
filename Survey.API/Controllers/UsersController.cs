using AutoMapper;
using Common.Types.Types.ServiceBus;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Api.Commands;
using Survey.Transverse.Contract.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IBusPublisher _busPublisher;

        public UsersController(IMapper mapper,
                               LinkGenerator linkGenerator,
                               IBusPublisher busPublisher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _busPublisher = busPublisher;
        }

        [HttpGet("")]
        public IActionResult Get() => Content("Hello from Actio.Services.Identity API!");


        [HttpPost]
        public IActionResult Register(UserRegistrationRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
            _busPublisher.SendAsync(registerCommand);

            return Accepted();
        }

    }

}
