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
    public class ChangePasswordHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IAuthenticationService _authenticationService;

        public ChangePasswordHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Result> Handle(ChangePasswordCommand command)
        {
            return await _authenticationService.ChangePassword(command.Id, command.NewPassword, command.OldPassword);
        }
    }
}
