using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Services.Users;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Users
{
    public class UnregisterUserHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly IUserService _userService;

        public UnregisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }
        public Task<Result> Handle(UnregisterUserCommand command)
        {
            return _userService.UnregisterUser(command.Id, command.By, command.Reason);
        }
    }
}
