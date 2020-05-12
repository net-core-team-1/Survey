using Identity.Api.Identity.Domain.AppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Services
{
    public interface IAppServiceRepository
    {
        AppService FindByKey(Guid id);
        void Insert(AppService entity);
        void Update(AppService entity);
        IEnumerable<AppService> FindByInclude(Expression<Func<AppService, bool>> predicate, params Expression<Func<AppService, object>>[] includeProperties);
        IEnumerable<AppService> FindBy(Expression<Func<AppService, bool>> predicate);
        bool Save();
    }
}
