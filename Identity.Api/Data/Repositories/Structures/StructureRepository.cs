using Identity.Api.Identity.Domain.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Structures
{
    public class StructureRepository : GenericRepository<Structure>, IStructureRepository
    {
        private readonly TransverseIdentityDbContext _context;

        public StructureRepository(TransverseIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public Structure FindByKey(Guid id)
        {
            return _context.Structures.Find(id);
        }

        public void Insert(Structure entity)
        {
            _context.Structures.Add(entity);
        }
        public void Update(Structure entity)
        {
            _context.Structures.Attach(entity);
        }
        public bool Save()
        {
            return _context.SaveChanges() < 0;
        }

        IEnumerable<Structure> IStructureRepository.FindBy(Expression<Func<Structure, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<Structure> IStructureRepository.FindByInclude(Expression<Func<Structure, bool>> predicate, params Expression<Func<Structure, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }
    }
}
