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

        public Entity FindByCode(string code)
        {
            var data = (from x in _context.Entities
                        where x.FuncCode.Code == code
                        select x).FirstOrDefault();
            return data;
        }

        public Entity FindByKey(Guid? id)
        {
            if (id == null)
                return null;
            return _context.Entities.Find(id);
        }

        public void Insert(Entity entity)
        {
            _context.Entities.Add(entity);
        }

        public bool IsCodeUsed(string code)
        {
            var data = (from x in _context.Entities
                        where x.FuncCode.Code == code
                        select new
                        {
                            x.Id
                        }).Count();
            return data > 0;
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
