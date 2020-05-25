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
    public class LogOutHandler : ICommandHandler<SignOutCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public LogOutHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Result> Handle(SignOutCommand command)
        {
            return await _authenticationService.LogOut(command.Id);
        }
    }
}
