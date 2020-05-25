using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Users
{
    public class ChangeEmailHandler : ICommandHandler<ChangeEmailCommand>
    {
        private readonly IUserService _userService;

        public ChangeEmailHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(ChangeEmailCommand command)
        {
            return await _userService.ChangeEmail(command.Id,command.Email);
        }
    }
}
