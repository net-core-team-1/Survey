using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Services.Seeders.Modules;
using Survey.Common.Seeding;
using Survey.Identity.Services.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders
{
    public class IdentitySeeder : IDatabaseSeeder
    {
        private readonly Dictionary<int, IModuleSeeder> _modules;
        private readonly Dictionary<int, IRootModuleSeeder> _rootModules;
        private Dictionary<SeederTypeName, RootSeederResult> _rootValues;

        public IdentitySeeder(IUserService userService
                , IStructureRepository structureRepository
                , IRootStructureSeeder rootStructureSeeder
                , IRootUserSeeder rootUserSeeder
                , IRootAppServiceSeeder rootAppServiceSeeder
                , IRootRoleSeeder rootRoleSeeder
                , IFeatureSeeder featureSeeder
                , IRoleFeatureSeeder roleFeatureSeeder
                , IUserSeeder userSeeder
                , ICivilitySeeder civilitySeeder
                )
        {
            int order = 0;
            _rootValues = new Dictionary<SeederTypeName, RootSeederResult>();

            _rootModules = new Dictionary<int, IRootModuleSeeder>() {
                {order++,civilitySeeder },
                {order++, rootStructureSeeder },
                {order++, rootUserSeeder },
                {order++, rootAppServiceSeeder },
                {order++, rootRoleSeeder }
            };

            _modules = new Dictionary<int, IModuleSeeder>() {
                { order++, featureSeeder },
                { order++ ,roleFeatureSeeder },
                { order++,userSeeder }
            };
        }

        public async Task SeedAsync()
        {
            foreach (var module in _rootModules.OrderBy(o => o.Key))
            {
                var result = await module.Value.SeedAsync(_rootValues);
                AddResultToRootValues(result);
            }

            foreach (var module in _modules.OrderBy(o => o.Key))
            {
                var result = module.Value.SeedAsync(_rootValues);
            }
        }
        private void AddResultToRootValues(List<RootSeederResult> items)
        {
            foreach (var item in items)
            {
                _rootValues.Add(item.Type, item);
            }
        }
    }
}
