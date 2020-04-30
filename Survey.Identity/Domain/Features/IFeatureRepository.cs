using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Survey.Identity.Domain.Features
{
    public interface IFeatureRepository
    {
        Feature FindByKey(Guid id);
        void Insert(Feature entity);
        IEnumerable<Feature> FindByInclude(Expression<Func<Feature, bool>> predicate, params Expression<Func<Feature, object>>[] includeProperties);
        IEnumerable<Feature> FindBy(Expression<Func<Feature, bool>> predicate);

        bool Save();
    }
}
