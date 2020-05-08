using Survey.Identity.Data;
using Survey.Identity.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace Survey.Identity.Infrastracture.Data.Repositories
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly SurveyIdentityContext _context;

        public FeatureRepository(SurveyIdentityContext context)
        {
            _context = context;
        }

        public Feature FindByKey(Guid id)
        {
            return _context.Features.Find(id);
        }

        public void Insert(Feature entity)
        {
            _context.Features.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }
        public bool DoesUserHaveAccessTo(Guid userId, string actionName)
        {

            var data =  from x in _context.Users
                        from y in _context.Roles
                        from xx in x.UserRoles
                        from yy in y.RoleFeatures
                        where x.Id == userId && yy.Feature.FeatureInfo.Action == actionName && xx.RoleId == y.Id
                        select new
                        {
                            x.Id
                        };


            return data.Count() > 0;

        }



    }
}
