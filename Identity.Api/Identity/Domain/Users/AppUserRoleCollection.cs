using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppUserRoles
{
    public class AppUserRoleCollection : ICollection<AppUserRole>
    {
        private readonly List<AppUserRole> _items = new List<AppUserRole>();
        public List<AppUserRole> Value => _items;
        public AppUserRoleCollection()
        {
        }
        protected AppUserRoleCollection(List<AppUserRole> items)
        {
            _items = items;
        }
        public static Result<AppUserRoleCollection> Create(List<AppUserRole> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<AppUserRoleCollection>("Empty roles list");
            }
            return Result.Success(new AppUserRoleCollection(items));
        }

        public static Result<AppUserRoleCollection> Create(Guid userId, Guid AppServiceId, List<Guid> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<AppUserRoleCollection>("Empty roles list");
            }
            var userRolesCollection = items.Select(x => new AppUserRole(x, userId)).ToList();
            return Result.Success<AppUserRoleCollection>(new AppUserRoleCollection(userRolesCollection));
        }

        public Result<AppUserRole> Add(AppUserRole line)
        {
            if (line == null || line.RoleId == Guid.Empty)
                return Result.Failure<AppUserRole>("Role is not defined");
            if (_items.Where(x => x.RoleId == line.RoleId).Count() != 0)
                return Result.Failure<AppUserRole>("Role already exist in collection");

            _items.Add(line);
            return Result.Success<AppUserRole>(line);
        }

        public int Count => _items.Count();

        public bool IsReadOnly => false;

        public IEnumerator<AppUserRole> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        void ICollection<AppUserRole>.Add(AppUserRole item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(AppUserRole item)
        {
            return _items.Where(x => x.UserId == item.UserId
                                     && x.RoleId == item.RoleId)
                         .Count() != 0;
        }

        public void CopyTo(AppUserRole[] array, int arrayIndex)
        {
            foreach (AppUserRole i in array)
            {
                array.SetValue(i, arrayIndex);
                arrayIndex = arrayIndex + 1;
            }
        }

        public bool Remove(AppUserRole item)
        {
            return _items.Remove(item);
        }
    }
}
