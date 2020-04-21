using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Survey.Transverse.Domain.Features
{
    public interface IPermissionRepository
    {
        Permission FindByKey(Guid id);
        void Insert(Permission entity);
        IEnumerable<Permission> FindBy(Expression<Func<Permission, bool>> predicate);
        IEnumerable<Permission> FindByInclude(Expression<Func<Permission, bool>> predicate, params Expression<Func<Permission, object>>[] includeProperties);

        bool Save();
    }
}
