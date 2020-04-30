using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Services.Users;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Handlers
{
    public class EditUserInfoHandler : ICommandHandler<EditUserInfoCommand>
    {
        private readonly IUserService _userService;

        public EditUserInfoHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result> Handle(EditUserInfoCommand command)
        {
            return await _userService.EdiInfo(command.Id,command.FirstName,command.LastName,command.Roles,command.DeleteExistingRoles);
        }
    }
}
