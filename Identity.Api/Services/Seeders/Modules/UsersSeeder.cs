using Identity.Api.Identity.Domain.Users.Commands;
using Survey.Common.Messages;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class UsersSeeder : IUserSeeder
    {
        private readonly IUserService _userService;
        private readonly Dispatcher _dispatcher;
        public UsersSeeder(IUserService userService, Dispatcher dispatcher)
        {
            _userService = userService;
            _dispatcher = dispatcher;
        }

        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid structureId = Guid.Parse(rootValues[SeederTypeName.Structure].Value);
            Guid adminRoleId = Guid.Parse(rootValues[SeederTypeName.AdminRole].Value);
            int civilityId = int.Parse(rootValues[SeederTypeName.MaleCivilityId].Value);
            var permission = new List<Guid>() { adminRoleId };
            RegisterUserCommand command =
                new RegisterUserCommand("Administrator", "Admin", "Admun", "Admin@mail.com", "Identity123#Admin", civilityId, permission, structureId);
            _dispatcher.Dispatch(command);

            var user = _userService.FindUserByUserNameAsync(command.UserName).Result;
            await Task.FromResult<RootSeederResult>(new RootSeederResult() { Type = SeederTypeName.RootUser, Value = user.Id.ToString() });
        }
    }
}
