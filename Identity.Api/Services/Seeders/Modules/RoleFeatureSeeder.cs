using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RoleFeatureSeeder : IRoleFeatureSeeder
    {
        private readonly IRoleService _roleService;
        private readonly IFeatureRepository _featureRepository;

        public RoleFeatureSeeder(IRoleService roleService,
              IFeatureRepository featureRepository)
        {
            _roleService = roleService;
            _featureRepository = featureRepository;
        }
        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            var adminRoleId = Guid.Parse(rootValues[SeederTypeName.AdminRole].Value);
            var rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            var features = _featureRepository.FindBy(x => !x.DisabeleInfo.Disabled.Value)
                                             .ToList();

            EditRoleFeatureCommand command = new EditRoleFeatureCommand(rootUserId, adminRoleId, features.Select(x => x.Id).ToList());
            var role = _roleService.FindRoleById(command.RoleId).Result;
            if (role == null)
                throw new IdentityException("ROLE_NOT_FOUND", "Role not found in database");
            if (role.RoleFeatures.Count() != 0)
                return;

            role.EditFeatures(command.AssignedBy, features);

            await _roleService.UpdateAsync(role);
        }
    }
}
