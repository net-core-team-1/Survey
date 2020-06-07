using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Common.Seeding
{
    public class IdentityDatabaseInitialier : IDatabaseInitializer
    {
        private readonly IDatabaseSeeder _seeder;
        public IdentityDatabaseInitialier(IDatabaseSeeder seeder)
        {
            _seeder = seeder;

        }

        public async Task InitializeAsync()
        {
            await _seeder.SeedAsync();
        }
    }
}
