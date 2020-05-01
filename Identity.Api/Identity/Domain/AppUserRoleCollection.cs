using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain
{
    public class AppUserRoleCollection : ValueObject, IEnumerable<AppUserRole>
    {
        private readonly List<AppUserRole> _items = new List<AppUserRole>();
        private readonly IDictionary<Guid, AppUserRole> _itemsByLineId = new Dictionary<Guid, AppUserRole>();
        public List<AppUserRole> Value => _items;
        protected AppUserRoleCollection(List<AppUserRole> items)
        {
            _items = items;
            foreach (var role in items)
            {
                _itemsByLineId.Add(role.RoleId, role);
            }
        }
        public static Result<AppUserRoleCollection> Create(List<AppUserRole> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<AppUserRoleCollection>("Empty roles list");
            }
            return Result.Success(new AppUserRoleCollection(items));
        }

        public static Result<AppUserRoleCollection> Create(List<Guid> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<AppUserRoleCollection>("Empty roles list");
            }

            return Result.Success<AppUserRoleCollection>(new AppUserRoleCollection(items.Select(x => new AppUserRole(x)).ToList()));
        }

        public Result<AppUserRole> Add(AppUserRole line)
        {
            if (line == null || line.RoleId == Guid.Empty)
                return Result.Failure<AppUserRole>("Role is not defined");
            if (_itemsByLineId.ContainsKey(line.RoleId))
                return Result.Failure<AppUserRole>("Role already exist in collection");

            _items.Add(line);
            _itemsByLineId.Add(line.RoleId, line);
            return Result.Success<AppUserRole>(line);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return _items;
        }
        public IEnumerator<AppUserRole> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
