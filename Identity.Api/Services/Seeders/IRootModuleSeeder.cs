using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders
{
    public interface IRootModuleSeeder
    {

        Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues);
    }
}
