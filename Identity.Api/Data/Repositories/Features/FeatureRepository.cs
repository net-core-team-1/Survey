using Identity.Api.Identity.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Features
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        private readonly TransverseIdentityDbContext _context;

        public FeatureRepository(TransverseIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public Feature FindByKey(Guid id)
        {
            return _context.Features.Find(id);
        }

        public void Insert(Feature entity)
        {
            _context.Features.Add(entity);
        }
        public void Update(Feature entity)
        {
            _context.Features.Attach(entity);
        }
        public bool Save()
        {
            return _context.SaveChanges() < 0;
        }

        IEnumerable<Feature> IFeatureRepository.FindBy(Expression<Func<Feature, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<Feature> IFeatureRepository.FindByInclude(Expression<Func<Feature, bool>> predicate, params Expression<Func<Feature, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }
    }
}
