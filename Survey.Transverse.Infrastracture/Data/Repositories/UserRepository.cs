using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Survey.Transverse.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Survey.Transverse.Infrastracture.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TransverseContext _context;


        public UserRepository(TransverseContext context)
        {
            _context = context;
        }

        public bool DoesUserHaveAccessTo(Guid userId, string actionName)
        {
           
            var data = (from x in _context.Users
                        from y in _context.Permissions
                        from xx in x.UserPermissions
                        from yy in y.PermissionFeatures
                        where x.Id == userId && yy.Feature.FeatureInfo.Action == actionName && xx.PermissionId == y.Id
                        select new
                        {
                            x.Id
                        });

            
            return data.Count() > 0;

        }

        public IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate)
        {
            IQueryable<User> results = _context.Users
                                               .Where(predicate);
            return results;
        }

        public User FindByKey(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return null;
            _context.Entry(user).Collection(a => a.UserPermissions).Load();

            return user;

        }

        public void Insert(User entity)
        {
            _context.Users.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }



    }
}
