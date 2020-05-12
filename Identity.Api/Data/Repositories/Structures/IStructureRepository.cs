using Identity.Api.Identity.Domain.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Structures
{
    public interface IStructureRepository
    {
        Structure FindByKey(Guid id);
        void Insert(Structure entity);
        void Update(Structure entity);
        IEnumerable<Structure> FindByInclude(Expression<Func<Structure, bool>> predicate, params Expression<Func<Structure, object>>[] includeProperties);
        IEnumerable<Structure> FindBy(Expression<Func<Structure, bool>> predicate);
        bool Save();
    }
}
