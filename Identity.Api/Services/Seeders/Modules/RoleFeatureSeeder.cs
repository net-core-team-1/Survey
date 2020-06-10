using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class RoleFeatureSeeder : IRoleFeatureSeeder
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly Dispatcher _dispatcher;

        public RoleFeatureSeeder(IFeatureRepository featureRepository, Dispatcher dispatcher)
        {
            _featureRepository = featureRepository;
            _dispatcher = dispatcher;
        }
        public async Task SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            var adminRoleId = Guid.Parse(rootValues[SeederTypeName.AdminRole].Value);
            var rootUserId = Guid.Parse(rootValues[SeederTypeName.RootUser].Value);
            var features = _featureRepository.FindBy(x => !x.DisabeleInfo.Disabled.Value)
                                             .ToList();

            EditRoleFeatureCommand command = new EditRoleFeatureCommand(rootUserId, adminRoleId, features.Select(x => x.Id).ToList());
            _dispatcher.Dispatch(command);
        }
    }
}
