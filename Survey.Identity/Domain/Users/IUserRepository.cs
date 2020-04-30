using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Survey.Identity.Domain.Users
{
    public interface IUserRepository
    {
        User FindByKey(Guid id);
        void Insert(User entity);
        IEnumerable<User> FindBy(Expression<Func<User, bool>> predicate);

        bool Save();
        bool DoesUserHaveAccessTo(Guid userId, string actionName);

        Task<User> FindByEmail(string email);
    }
}
