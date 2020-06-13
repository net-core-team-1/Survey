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
