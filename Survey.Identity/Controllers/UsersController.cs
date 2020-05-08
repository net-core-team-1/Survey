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
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly AsyncDispatcher _dispatcher;

        public UsersController(
                               IMapper mapper,
                               LinkGenerator linkGenerator,
                               AsyncDispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
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


        [HttpPost(ApiRoutes.Users.ChangeEmail)]
        public async Task<IActionResult> ChangeEmail(Guid id, ChangeEmailRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<ChangeEmailCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return Ok();
        }


    }
}
