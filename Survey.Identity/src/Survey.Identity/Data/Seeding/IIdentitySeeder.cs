using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding
{
    public interface IIdentitySeeder
    {
        public Task<Result> SeedAsync();
    }
}
