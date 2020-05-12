using Identity.Api.Identity.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Identity.Api.Data.Repositories.Features
{
    public interface IFeatureRepository
    {
        Feature FindByKey(Guid id);
        void Insert(Feature entity);
        void Update(Feature entity);
        IEnumerable<Feature> FindByInclude(Expression<Func<Feature, bool>> predicate, params Expression<Func<Feature, object>>[] includeProperties);
        IEnumerable<Feature> FindBy(Expression<Func<Feature, bool>> predicate);

        bool Save();
    }
}
