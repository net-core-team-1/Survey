using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Identity.Api.Contrats.Authentication.Requests;
using Identity.Api.Identity.Domain.Authentication.Commands;
using Identity.Api.IdentityServices.Authentication;
using Microsoft.AspNetCore.Mvc;
using Survey.Common.Messages;

namespace Identity.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICommandSender _commandSender;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService,
                                        IMapper mapper,
                                        ICommandSender commandSender)
        {
            _mapper = mapper;
            _commandSender = commandSender;
            _authenticationService = authenticationService;
        }


        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInRequest request)
        {
            var command = _mapper.Map<SignInCommand>(request);
            var result = await _commandSender.SendAsync(command);
            if (result.IsSuccess)
            {
                var token = await _authenticationService.IssueWebToken(request.UserName);
                return Ok(token);
            }
            return Ok(result);
        }

        [HttpPost("SignOut")]
        public IActionResult SignOut(Guid id)
        {
            SignOutRequest request = new SignOutRequest(id);
            var command = _mapper.Map<SignOutCommand>(request);
            var result = _commandSender.Send(command);
            return Ok(result);
        }

        [HttpPost("ChangePassword")]
        public IActionResult ChangePassword(Guid id, ChangePasswordRequest request)
        {
            request.Id = id;
            var command = _mapper.Map<ChangePasswordCommand>(request);
            var result = _commandSender.Send(command);
            return Ok(result);
        }

        [HttpPost("Refresh")]
        public IActionResult RefreshToken(string token)
        {
            var result = _authenticationService.RefreshToken(token).Result;
            if (result.IsSuccess)
            {
                return Ok(result.Value);
            }
            return Ok(result);
        }


    }
}