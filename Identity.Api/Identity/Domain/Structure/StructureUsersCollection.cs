using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure
{
    public class StructureUsersCollection : IEnumerable<StructureUsers>
    {
        private readonly List<StructureUsers> _items = new List<StructureUsers>();
        public virtual IReadOnlyList<StructureUsers> Value => _items;
        protected StructureUsersCollection() { }
        private StructureUsersCollection(List<StructureUsers> items)
        {
            _items = items;
        }
        public static Result<StructureUsersCollection> Create(Guid structureId, List<AppUser> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<StructureUsersCollection>("Empty feature list");
            }

            return Result.Success<StructureUsersCollection>(
                new StructureUsersCollection(items.Select(x => new StructureUsers(structureId, x.Id))
                                                    .ToList()));
        }

        public Result<StructureUsers> Add(StructureUsers structureUser)
        {
            if (structureUser == null || structureUser.StructureId == Guid.Empty)
                return Result.Failure<StructureUsers>("Structure is not defined");
            if (structureUser.UserId == Guid.Empty)
                return Result.Failure<StructureUsers>("User is not defined");

            if (_items.Where(x => x.UserId == structureUser.UserId).Count() != 0)
                return Result.Failure<StructureUsers>("User already exist in structure users collection");

            _items.Add(structureUser);
            return Result.Success<StructureUsers>(structureUser);
        }

        public IEnumerator<StructureUsers> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
