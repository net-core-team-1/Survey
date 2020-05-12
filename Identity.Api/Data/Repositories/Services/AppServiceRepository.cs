using Identity.Api.Identity.Domain.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Services
{
    public class AppServiceRepository : GenericRepository<AppService>, IAppServiceRepository
    {
        private readonly TransverseIdentityDbContext _context;

        public AppServiceRepository(TransverseIdentityDbContext context) : base(context)
        {
            _context = context;
        }

        public AppService FindByKey(Guid id)
        {
            return _context.AppServices.Find(id);
        }

        public void Insert(AppService entity)
        {
            _context.AppServices.Add(entity);
        }
        public void Update(AppService entity)
        {
            _context.AppServices.Attach(entity);
        }
        IEnumerable<AppService> IAppServiceRepository.FindBy(Expression<Func<AppService, bool>> predicate)
        {
            return base.FindBy(predicate);
        }

        IEnumerable<AppService> IAppServiceRepository.FindByInclude(Expression<Func<AppService, bool>> predicate, params Expression<Func<AppService, object>>[] includeProperties)
        {
            return base.FindByInclude(predicate, includeProperties);
        }
        public bool Save()
        {
            return _context.SaveChanges() < 0;
        }
    }
}
