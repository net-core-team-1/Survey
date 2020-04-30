using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Survey.Identity.Domain.Users;
using Survey.Transverse.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Survey.Identity.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SurveyIdentityContext _context;
        private readonly UserManager<User> _userManager;

        public UserRepository(SurveyIdentityContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public bool DoesUserHaveAccessTo(Guid userId, string actionName)
        {
           
            var data = (from x in _context.Users
                        from y in _context.Roles
                        from xx in x.UserRoles
                        from yy in y.RoleFeatures
                        where x.Id == userId && yy.Feature.FeatureInfo.Action == actionName && xx.RoleId == y.Id
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

        public Task<User> FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User FindByKey(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return null;
            _context.Entry(user).Collection(a => a.UserRoles).Load();

            return user;

        }

        public void Insert(User entity)
        {
            //_userManager
            _context.Users.Add(entity);
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }



    }
}
