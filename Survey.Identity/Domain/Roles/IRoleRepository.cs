using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Survey.Identity.Domain.Roles
{
    public interface IRoleRepository
    {
        Role FindByKey(Guid id);
        void Insert(Role entity);
        IEnumerable<Role> FindBy(Expression<Func<Role, bool>> predicate);
        IEnumerable<Role> FindByInclude(Expression<Func<Role, bool>> predicate, params Expression<Func<Role, object>>[] includeProperties);

        bool Save();
    }
}
