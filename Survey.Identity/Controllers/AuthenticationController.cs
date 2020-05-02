using AutoMapper;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Survey.Common.Messages;
using Survey.Identity.Contracts;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Services.Authentication;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Controllers
{
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        private readonly AsyncDispatcher _dispatcher;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService,
                                        IMapper mapper,
                                        LinkGenerator linkGenerator,
                                        AsyncDispatcher dispatcher)
        {
            _mapper = mapper;
            _linkGenerator = linkGenerator;
            _dispatcher = dispatcher;
            _authenticationService = authenticationService;
        }


        [HttpPost(ApiRoutes.Identity.SignIn)]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var command = _mapper.Map<SignInCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            if (result.IsSuccess)
            {
                var token = await _authenticationService.IssueWebToken(request.Email);
                return Ok(token);
            }
            return FromResult(result);
        }



        [HttpPost(ApiRoutes.Identity.SignOut)]
        public async Task<IActionResult> SignOut(Guid id)
        {
            SignOutRequest request = new SignOutRequest(id);
            var command = _mapper.Map<SignOutCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);         
        }

        [HttpPost(ApiRoutes.Identity.ChangePassword)]
        public async Task<IActionResult> ChangePassword(Guid id,ChangePasswordRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<ChangePasswordCommand>(request);
            var result = await _dispatcher.Dispatch(command);
            return FromResult(result);
        }


    }
}
