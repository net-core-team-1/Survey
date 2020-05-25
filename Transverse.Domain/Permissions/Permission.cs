using Survey.CQRS.Commands;
using Survey.Transverse.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Survey.Transverse.Domain.Permissions
{
    public class Permission : BaseEntity
    {
        public virtual CreateInfo CreateInfo { get; private set; }

        public virtual PermissionInfo PermissionInfo { get; private set; }

        public virtual DisabeleInfo DisabeleInfo { get; private set; }

        public virtual DeleteInfo DeleteInfo { get; private set; }


        private readonly List<PermissionFeature> _permissionFeatures = new List<PermissionFeature>();
        public virtual IReadOnlyList<PermissionFeature> PermissionFeatures => _permissionFeatures.ToList();


        protected Permission()
        {

        }

        public Permission(PermissionInfo permissionInfo, CreateInfo creationInfo, List<Guid> features = null)
        {

            PermissionInfo = permissionInfo;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisabeleInfo = DisabeleInfo.Create().Value;

            UpdateFeatures(features, true);
        }

        public void Deactivate(DisabeleInfo disableInfo)
        {
            DisabeleInfo = disableInfo;
        }

        public void Update(PermissionInfo permissionInfo, List<Guid> features = null, bool deleteExisting = false)
        {
            UpdateInfo(permissionInfo);
            UpdateFeatures(features, deleteExisting);
        }
        private void UpdateInfo(PermissionInfo permissionInfo)
        {
            if (PermissionInfo != permissionInfo)
                PermissionInfo = permissionInfo;
        }
        private void UpdateFeatures(List<Guid> features, bool deleteExisting = false)
        {
            List<Guid> toAdd = features.Where(a => _permissionFeatures.Where(b => b.Feature.Id == a).Count() == 0).ToList();
            List<PermissionFeature> toDelete = _permissionFeatures.Where(a => features.Where(b => b == a.Feature.Id).Count() == 0)
                .ToList();

            if (toDelete.Count() != 0)
                toDelete.ForEach(a => _permissionFeatures.Remove(a));
            if (toAdd.Count() != 0)
                toAdd.ForEach(a => _permissionFeatures.Add(PermissionFeature.Create(this.Id, a)));

        }

        public void Remove(DeleteInfo deletionInfo)
        {
            MarkAsDeleted(deletionInfo);
        }
        private void MarkAsDeleted(DeleteInfo deletionInfo)
        {
            DeleteInfo = deletionInfo;
        }
    }
}
