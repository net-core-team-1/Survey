using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain.RoleFeature;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles
{
    public class AppRoleFeaturesCollection : ICollection<AppRoleFeatures>
    {
        private readonly List<AppRoleFeatures> _items = new List<AppRoleFeatures>();
        public List<AppRoleFeatures> Value => _items;
        public AppRoleFeaturesCollection()
        {
        }
        protected AppRoleFeaturesCollection(List<AppRoleFeatures> items)
        {
            _items = items;
        }
        public static Result<AppRoleFeaturesCollection> Create(List<AppRoleFeatures> items)
        {
            if (items == null || items.Count() == 0)
            {
                return Result.Failure<AppRoleFeaturesCollection>("Empty roles list");
            }
            return Result.Success(new AppRoleFeaturesCollection(items));
        }

        public static Result<AppRoleFeaturesCollection> Create(Guid createdBy, Guid roleId, List<Guid> featureIds)
        {
            if (featureIds == null || featureIds.Count() == 0)
            {
                return Result.Failure<AppRoleFeaturesCollection>("Empty roles list");
            }
            var userRolesCollection = featureIds.Select(x => new AppRoleFeatures(createdBy, roleId, x)).ToList();
            return Result.Success<AppRoleFeaturesCollection>(new AppRoleFeaturesCollection(userRolesCollection));
        }

        public Result<AppRoleFeatures> Add(AppRoleFeatures row)
        {
            if (row == null || row.RoleId == Guid.Empty)
                return Result.Failure<AppRoleFeatures>("Role is not defined");
            if (_items.Where(x => x.RoleId == row.RoleId && x.FeatureId == row.FeatureId).Count() != 0)
                return Result.Failure<AppRoleFeatures>("Role already exist in collection");

            _items.Add(row);
            return Result.Success<AppRoleFeatures>(row);
        }

        public int Count => _items.Count();

        public bool IsReadOnly => false;

        void ICollection<AppRoleFeatures>.Add(AppRoleFeatures item)
        {
            _items.Add(item);
        }

        public void Clear()
        {
            _items.Clear();
        }

        public bool Contains(AppRoleFeatures item)
        {
            return _items.Where(x => x.RoleId == item.RoleId && x.FeatureId == item.FeatureId)
                         .Count() != 0;
        }

        public void CopyTo(AppRoleFeatures[] array, int arrayIndex)
        {
            foreach (AppRoleFeatures i in array)
            {
                array.SetValue(i, arrayIndex);
                arrayIndex = arrayIndex + 1;
            }
        }

        internal void RemoveRange(List<AppRoleFeatures> featuresToRemove)
        {
            _items.RemoveAll(x => featuresToRemove
                                     .Where(f => f.FeatureId == x.FeatureId
                                             && f.RoleId == x.RoleId)
                                     .Count() != 0);
        }

        internal void AddRange(List<AppRoleFeatures> featuresToAdd)
        {
            _items.AddRange(featuresToAdd);
        }

        public bool Remove(AppRoleFeatures item)
        {
            return _items.Remove(item);
        }
        public IEnumerator<AppRoleFeatures> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

    }
}
