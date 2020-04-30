using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Domain.Users.Commands;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Handlers
{
    public class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserService _userService;

        public RegisterUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result> Handle(RegisterUserCommand command)
        {
            return await _userService.RegisterUser(command.FirstName, command.LastName, command.Email, command.Password, command.Roles);
        }
    }
}
