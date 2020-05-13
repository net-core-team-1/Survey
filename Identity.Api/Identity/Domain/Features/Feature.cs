using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Roles;
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
        public virtual Guid ServiceId { get; private set; }
        public virtual AppService Service { get; private set; }
        public virtual AppRoleFeaturesCollection RoleFeatures { get; protected set; }
        protected Feature()
        {
            RoleFeatures = new AppRoleFeaturesCollection();
        }
        public Feature(Guid featureId)
        {
            this.Id = featureId;

        }
        public Feature(FeatureInfo featureInfo, CreateInfo creationInfo, AppService appService)
        {
            Id = Guid.NewGuid();
            FeatureInfo = featureInfo;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisabeleInfo = DisabeleInfo.Create().Value;
            Service = appService;
        }

        internal void ChangeService(AppService appService)
        {
            Service = appService;
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
