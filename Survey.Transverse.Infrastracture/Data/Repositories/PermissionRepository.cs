using Microsoft.EntityFrameworkCore;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly TransverseContext _context;

        public PermissionRepository(TransverseContext context) 
        {
            _context = context;
        }


        public Permission FindByKey(Guid id)
        {
            var permission = _context.Permissions.Find(id);
            if (permission == null)
                return null;
            _context.Entry(permission).Collection(a => a.PermissionFeatures).Load();

            return permission;

        }

        public void Insert(Permission entity)
        {
            _context.Permissions.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges()>0;
        }

        public IEnumerable<Permission> FindBy(Expression<Func<Permission, bool>> predicate)
        {
            IQueryable<Permission> results = _context.Permissions
                                               .Where(predicate);
            return results;
        }
        public IEnumerable<Permission> FindByInclude(Expression<Func<Permission, bool>> predicate, params Expression<Func<Permission, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            IQueryable<Permission> results = query.Where(predicate);
            return results;
        }
        private IQueryable<Permission> GetAllIncluding(params Expression<Func<Permission, object>>[] includeProperties)
        {
            IQueryable<Permission> queryable = _context.Permissions;

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
