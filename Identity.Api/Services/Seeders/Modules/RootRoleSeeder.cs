using Identity.Api.Data.Repositories.Services;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Identity.Api.Utils.ResultValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RootRoleSeeder : IRootRoleSeeder
    {
        private readonly IRoleService _roleService;
        private readonly IStructureRepository _structureRepository;
        private readonly IAppServiceRepository _serviceRepository;

        public RootRoleSeeder(IRoleService roleService
            , IStructureRepository structureRepository
            , IAppServiceRepository serviceRepository)
        {
            _roleService = roleService;
            _structureRepository = structureRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            Guid rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            Guid rootStructureId = Guid.Parse(rootValues[SeederTypeName.Structure].Value);
            Guid rootAppServiceId = Guid.Parse(rootValues[SeederTypeName.AppService].Value);

            var command = new RegisterRoleCommand("ADMINISTRATOR", "Admin role", rootUserId, rootAppServiceId, rootStructureId);
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure_not_found", "the given structure id not found in database.");

            var appService = _serviceRepository.FindByKey(command.AppServiceId);
            if (appService == null)
                throw new IdentityException("App_service_not_found", "the given AppService id not found in database.");

            var role = _roleService.FindRoleByName(command.Name).Result;
            if (role != null)
                return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.AdminRole, Value = role.Id.ToString() } });

            var createInfoResult = CreateInfo.Create(command.CreatedBy).Validate();
            var rootRole = new AppRole(createInfoResult.Value, command.Name, command.Description,
                appService.Id, structure.Id);
            await _roleService.RegisterNewAsync(rootRole);

            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { new RootSeederResult() { Type = SeederTypeName.AdminRole, Value = rootRole.Id.ToString() } });

        }
    }
}
