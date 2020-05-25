using CSharpFunctionalExtensions;

using Survey.CQRS.Commands;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Services.Authentication;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Authentication
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
            return await _authenticationService.LoginAsync(command.Email, command.Password);
        }
    }
}
