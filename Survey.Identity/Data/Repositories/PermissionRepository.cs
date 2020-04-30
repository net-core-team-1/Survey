using Microsoft.EntityFrameworkCore;
using Survey.Identity.Data;
using Survey.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SurveyIdentityContext _context;

        public RoleRepository(SurveyIdentityContext context) 
        {
            _context = context;
        }


        public Role FindByKey(Guid id)
        {
            var permission = _context.Roles.Find(id);
            if (permission == null)
                return null;
            _context.Entry(permission).Collection(a => a.RoleFeatures).Load();

            return permission;

        }

        public void Insert(Role entity)
        {
            _context.Roles.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges()>0;
        }

        public IEnumerable<Role> FindBy(Expression<Func<Role, bool>> predicate)
        {
            IQueryable<Role> results = _context.Roles
                                               .Where(predicate);
            return results;
        }
        public IEnumerable<Role> FindByInclude(Expression<Func<Role, bool>> predicate, params Expression<Func<Role, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IQueryable<Role> results = query.Where(predicate);
            return results;
        }
        private IQueryable<Role> GetAllIncluding(params Expression<Func<Role, object>>[] includeProperties)
        {
            IQueryable<Role> queryable = _context.Roles;

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
