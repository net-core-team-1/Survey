using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Authentication.Commands;
using Identity.Api.IdentityServices.Authentication;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Authentication
{
    public class SignInHandler : ICommandHandler<SignInCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public SignInHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Result> Handle(SignInCommand command)
        {
            return await _authenticationService.LoginAsync(command.UserName, command.Password);
        }
    }
}
