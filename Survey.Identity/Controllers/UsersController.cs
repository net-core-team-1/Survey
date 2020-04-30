using AutoMapper;
using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Services.Users;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    //[Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly IUserService _userService;
       // private readonly IBusPublisher _busPublisher;
        private readonly AsyncDispatcher _dispatcher;

        public UsersController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               IUserService userService,
                               //IBusPublisher busPublisher,
                               AsyncDispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _userService = userService;
          //  _busPublisher = busPublisher;
            _dispatcher = dispatcher;
        }


        [HttpPost(ApiRoutes.Users.Register)]
        public async Task<IActionResult> Register(UserRegistrationRequest registerRequest)
        {
            var registerCommand = _mapper.Map<RegisterUserCommand>(registerRequest);
            var result = await _dispatcher.Dispatch(registerCommand);
            return Ok();
        }

        [HttpPost(ApiRoutes.Users.EditeInfo)]
        public async Task<IActionResult> Edit(Guid id,EditUserInfoRequest editInfoRequest)
        {
            editInfoRequest.Id = id;
            var editInfoCommand = _mapper.Map<EditUserInfoCommand>(editInfoRequest);
            var result = await _dispatcher.Dispatch(editInfoCommand);
            return Ok();
        }

    }
}
