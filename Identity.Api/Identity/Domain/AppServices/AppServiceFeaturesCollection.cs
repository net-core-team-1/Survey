using Identity.Api.Identity.Domain.Features;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices
{
    public class AppServiceFeaturesCollection : ICollection<Feature>
    {
        private readonly List<Feature> _items = new List<Feature>();
        public List<Feature> Value => _items;
        public AppServiceFeaturesCollection()
        {
        }
        public AppServiceFeaturesCollection(List<Feature> items)
        {
            _items = items;
        }
        public int Count => _items.Count();

        public bool IsReadOnly => false;

        public void Add(Feature item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(Feature item)
        {
            return _items.Where(x => x.Id == item.Id)
                       .Count() != 0;
        }

        public void CopyTo(Feature[] array, int arrayIndex)
        {
            foreach (Feature i in array)
            {
                array.SetValue(i, arrayIndex);
                arrayIndex = arrayIndex + 1;
            }
        }

        public bool Remove(Feature item)
        {
            return _items.Remove(item);
        }
        public IEnumerator<Feature> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
