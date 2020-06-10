using Identity.Api.Data.Repositories.Services;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootRoleSeeder : IRootRoleSeeder
    {
        private readonly IRoleService _roleService;
        private readonly Dispatcher _dispatcher;

        public RootRoleSeeder(IRoleService roleService
            , IAppServiceRepository serviceRepository
            , Dispatcher dispatcher)
        {
            _roleService = roleService;
            _dispatcher = dispatcher;
        }

        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            Guid rootStructureId = Guid.Parse(rootValues[SeederTypeName.Structure].Value);
            Guid rootAppServiceId = Guid.Parse(rootValues[SeederTypeName.AppService].Value);

            var command = new RegisterRoleCommand("ADMINISTRATOR", "Admin role", rootUserId, rootAppServiceId, rootStructureId);
            _dispatcher.Dispatch(command);

            var role = _roleService.FindRoleByName(command.Name).Result;
            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>()
            {
                new RootSeederResult()
                {
                    Type = SeederTypeName.AdminRole, Value = role.Id.ToString()
                }
            });
        }
    }
}
