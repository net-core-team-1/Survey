using Identity.Api.Data;
using Identity.Api.Identity.Domain.Civilities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Seeders.Modules
{
    public class CivilitySeeder : ICivilitySeeder
    {
        private readonly TransverseIdentityDbContext _context;
        public CivilitySeeder(TransverseIdentityDbContext context)
        {
            _context = context;
        }


        public async Task<List<RootSeederResult>> SeedAsync(Dictionary<SeederTypeName, RootSeederResult> rootValues)
        {
            var maleCivilityId = new RootSeederResult() { Type = SeederTypeName.MaleCivilityId, Value = "1" };
            var femaleCivilityId = new RootSeederResult() { Type = SeederTypeName.FemaleCivility, Value = "2" };
            if (_context.Civilities.Count() != 0)
                return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { maleCivilityId, femaleCivilityId });

            _context.Civilities.Add(new Civility(1, "M.", "Monsieur"));
            _context.Civilities.Add(new Civility(2, "Mme", "Madame"));
            await _context.SaveChangesAsync();

            return await Task.FromResult<List<RootSeederResult>>(new List<RootSeederResult>() { maleCivilityId, femaleCivilityId });

        }

    }
}
