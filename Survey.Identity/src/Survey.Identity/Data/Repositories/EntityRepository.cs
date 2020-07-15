using Survey.Identity.Data;
using Survey.Identity.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using Survey.Identity.Domain.Entities;
using System.Security.Cryptography;

namespace Survey.Identity.Infrastracture.Data.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly SurveyIdentityContext _context;

        public EntityRepository(SurveyIdentityContext context)
        {
            _context = context;
        }


        public Entity FindByKey(Guid? id)
        {
            if (id == null)
                return null;
            return _context.Entities.FirstOrDefault(a => a.Id == id);
        }

        public List<Entity> GetAll()
        {
            return _context.Entities.ToList();
        }

        public void Insert(Entity entity)
        {
            _context.Entities.Add(entity);
        }


        public bool Save()
        {
            bool returnValue = false;
            try
            {
                _context.SaveChanges();
                returnValue = true;
            }
            catch (Exception ex)
            {
                returnValue = false;
            }
            return returnValue;
        }






    }
}
