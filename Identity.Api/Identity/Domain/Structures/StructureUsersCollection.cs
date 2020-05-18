using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.Users;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures
{
    public class StructureUsersCollection : ICollection<StructureUsers>
    {
        private readonly List<StructureUsers> _items = new List<StructureUsers>();
        public virtual IReadOnlyList<StructureUsers> Value => _items;

        public StructureUsersCollection() { }
        private StructureUsersCollection(List<StructureUsers> items)
        {
            _items = items;
        }
        public static Result<StructureUsersCollection> Create(Guid structureId, List<AppUser> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<StructureUsersCollection>("Empty users list");
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

        internal void RemoveRange(List<StructureUsers> StructureUsers)
        {
            _items.RemoveAll(x => StructureUsers
                                     .Where(f => f.StructureId == x.StructureId
                                             && f.UserId == x.UserId)
                                     .Count() != 0);
        }

        internal void AddRange(List<StructureUsers> StructureUsers)
        {
            _items.AddRange(StructureUsers);
        }

        public int Count => _items.Count();

        public bool IsReadOnly => false;

        void ICollection<StructureUsers>.Add(StructureUsers item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(StructureUsers item)
        {
            return _items.Where(x => x.UserId == item.UserId && x.StructureId == item.StructureId)
                         .Count() != 0;
        }

        public void CopyTo(StructureUsers[] array, int arrayIndex)
        {
            foreach (StructureUsers i in array)
            {
                array.SetValue(i, arrayIndex);
                arrayIndex = arrayIndex + 1;
            }
        }

        public bool Remove(StructureUsers item)
        {
            _items.RemoveAll(x => x.UserId == item.UserId && x.StructureId == item.StructureId);
            return _items.Where(x => x.UserId == item.UserId && x.StructureId == item.StructureId).Count() == 0;
        }
    }
}
