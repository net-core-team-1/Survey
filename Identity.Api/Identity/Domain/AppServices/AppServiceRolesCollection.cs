using Identity.Api.Identity.Domain.Roles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices
{
    public class AppServiceRolesCollection: ICollection<AppRole>
    {
        private readonly List<AppRole> _items = new List<AppRole>();
        public List<AppRole> Value => _items;
        public AppServiceRolesCollection()
        {
        }
        protected AppServiceRolesCollection(List<AppRole> items)
        {
            _items = items;
        }
        public int Count => _items.Count();

        public bool IsReadOnly => false;

        public void Add(AppRole item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(AppRole item)
        {
            return _items.Where(x => x.Id == item.Id)
                       .Count() != 0;
        }

        public void CopyTo(AppRole[] array, int arrayIndex)
        {
            foreach (AppRole i in array)
            {
                array.SetValue(i, arrayIndex);
                arrayIndex = arrayIndex + 1;
            }
        }

        public bool Remove(AppRole item)
        {
            return _items.Remove(item);
        }
        public IEnumerator<AppRole> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
