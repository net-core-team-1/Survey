using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Seeding
{
    public class DataBaseSeeder : IDatabaseSeeder
    {
        private readonly IEnumerable<IIdentitySeeder> _identitySeeders;
        private readonly SurveyIdentityContext _context;

        public DataBaseSeeder(IEnumerable<IIdentitySeeder> identitySeeders, SurveyIdentityContext context)
        {
            _identitySeeders = identitySeeders;
            _context = context;
        }

        public bool CanSeed()
        {
            return _context.Entities.Count() == 0;
        }

        public async Task<Result> SeedAsync()
        {
            var result = Result.Failure("list_seeder_is_empty");
            bool canSeed = CanSeed();
            //if (!canSeed)
            //    return result;

            foreach (var item in _identitySeeders)
            {
                var itemResult = await item.SeedAsync();
                if (itemResult.IsFailure)
                {
                    result = itemResult;
                    break;
                }
            }
            if (result.IsFailure)
                throw new NotImplementedException();
            return result;
        }
    }
}
