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
    //public class EntityLevelRepository : IEntityLevelRepository
    //{
    //    private readonly SurveyIdentityContext _context;

    //    public EntityLevelRepository(SurveyIdentityContext context)
    //    {
    //        _context = context;
    //    }



    //    public EntityLevel FindByKey(Guid? id)
    //    {
    //        if (id == null)
    //            return null;
    //        return _context.EntityLevels.Find(id);
    //    }

    //    public void Insert(EntityLevel entity)
    //    {
    //        _context.EntityLevels.Add(entity);
    //    }

    //    public bool IsNameAvailibale(string name)
    //    {
    //        var data = _context.EntityLevels.
    //                    Where(a => a.NameDesciption.Name == name).
    //                    FirstOrDefault();
    //        return data == null;
    //    }

    //    public bool Save()
    //    {
    //        return _context.SaveChanges() > 0;
    //    }




    //}
}
