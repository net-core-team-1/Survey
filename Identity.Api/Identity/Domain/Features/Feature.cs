using Identity.Api.Identity.Domain.RoleFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Features
{
    public class Feature
    {

        public Guid Id { get; private set; }
        public byte[] Timestamp { get; private set; }

        public virtual FeatureInfo FeatureInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }
        public virtual DisabeleInfo DisabeleInfo { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }

        private readonly List<AppRoleFeatures> _roles = new List<AppRoleFeatures>();
        public virtual IReadOnlyList<AppRoleFeatures> Roles => _roles.ToList();

        protected Feature()
        {

        }
        public Feature(Guid featureId)
        {
            this.Id = featureId;
           
        }
        public Feature(FeatureInfo featureInfo, CreateInfo creationInfo)
        {
            Id = Guid.NewGuid();
            FeatureInfo = featureInfo;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisabeleInfo = DisabeleInfo.Create().Value;
        }

        public void Deactivate(DisabeleInfo disableInfo)
        {
            DisabeleInfo = disableInfo;
        }

        public void UpdateInfo(FeatureInfo featureInfo)
        {
            FeatureInfo = featureInfo;
        }

        public void Remove(DeleteInfo deletionObj)
        {
            MarkAsDeleted(deletionObj);
        }
        private void MarkAsDeleted(DeleteInfo deletionObj)
        {
            DeleteInfo = deletionObj;
        }
    }
}
