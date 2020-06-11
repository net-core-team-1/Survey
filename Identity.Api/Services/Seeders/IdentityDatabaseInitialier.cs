using Identity.Api.Data.Repositories.Services;
using Survey.Common.Seeding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders
{
    public class IdentityDatabaseInitialier : IDatabaseInitializer
    {
        private readonly IAppServiceRepository _appServiceRepository;
        private readonly IDatabaseSeeder _seeder;
        public IdentityDatabaseInitialier(IDatabaseSeeder seeder, IAppServiceRepository appServiceRepository)
        {
            _seeder = seeder;
            _appServiceRepository = appServiceRepository;
        }

        public async Task InitializeAsync()
        {
            if (_appServiceRepository.FindByInclude(x => x.Id != Guid.Empty).Count() == 0)
                await _seeder.SeedAsync();
        }
    }
}
