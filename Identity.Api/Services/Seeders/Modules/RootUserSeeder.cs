using Identity.Api.Identity.Domain.Users.Commands;
using Survey.Common.Messages;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootUserSeeder : IRootUserSeeder
    {
        private readonly IUserService _userService;
        private readonly Dispatcher _dispatcher;
        public RootUserSeeder(IUserService userService
                             , Dispatcher dispatcher)
        {
            _userService = userService;
            _dispatcher = dispatcher;
        }
        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid structureId = Guid.Parse(rootValues[SeederTypeName.Structure].Value);
            int civilityId = int.Parse(rootValues[SeederTypeName.MaleCivilityId].Value);
            var permission = new List<Guid>();
            RegisterUserCommand command =
                new RegisterUserCommand("RootUser", "RootUser", "RootUser", "RootUser@mail.com", "Identity123#Root", civilityId, permission, structureId);

            _dispatcher.Dispatch(command);

            var user = _userService.FindUserByUserNameAsync(command.UserName).Result;
            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>()
            {
                new RootSeederResult() { Type = SeederTypeName.RootUser, Value = user.Id.ToString() }
            });
        }

    }
}
