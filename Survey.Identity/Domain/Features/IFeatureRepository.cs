using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Survey.Identity.Domain.Features
{
    public interface IFeatureRepository
    {
        Feature FindByKey(Guid id);
        void Insert(Feature entity);
        bool DoesUserHaveAccessTo(Guid userId, string actionName);

        bool Save();
    }
}
