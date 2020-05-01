using Identity.Api.Identity.Domain.Civilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Data.Repositories.Civilities
{
    public class CivilityRepository : GenericRepository<Civility>, ICivilityRepository
    {
        private readonly TransverseIdentityDbContext _context;

        public CivilityRepository(TransverseIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNew(Civility civility)
        {
            await _context.Civilities.AddAsync(civility);
        }

        public List<Civility> GetAll()
        {
            return _context.Civilities.ToList();
        }

        public void Update(Civility civility)
        {
            _context.Civilities.Update(civility);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
