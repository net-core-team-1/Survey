using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Domain.Authentication.Commands;
using Survey.Identity.Services.Authentication;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Authentication
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
