using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Messaging;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Users.Commands;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly DispatcherAsync _dispatcher;

        public UsersController(IMapper mapper,LinkGenerator linkGenerator,DispatcherAsync dispatcher)
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
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Users.EditeInfo)]
        public async Task<IActionResult> Edit(Guid id,EditUserInfoRequest editInfoRequest)
        {
            editInfoRequest.Id = id;
            var editInfoCommand = _mapper.Map<EditUserInfoCommand>(editInfoRequest);
            editInfoCommand.Roles = editInfoRequest.Roles;
            var result = await _dispatcher.Dispatch(editInfoCommand);
            return FromResult(result);
        }


        [HttpPost(ApiRoutes.Users.ChangeEmail)]
        public async Task<IActionResult> ChangeEmail(Guid id, ChangeEmailRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<ChangeEmailCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpPost(ApiRoutes.Users.Unregister)]
        public async Task<IActionResult> Unregister(Guid id,UnregisterRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<UnregisterUserCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


    }
}
