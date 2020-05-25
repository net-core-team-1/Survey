using Survey.Identity.Domain.Services;
using System;

namespace Survey.Identity.Domain.Features
{
    public class Feature
    {
        public Guid Id { get; private set; }
        public virtual FeatureInfo FeatureInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }
        public virtual DisableInfo DisableInfo { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }
        public byte[] Timestamp { get; private set; }

        public virtual MicroService MicroService { get; private set; }


        protected Feature()
        {

        }
        public Feature(FeatureInfo featureInfo, CreateInfo creationInfo,MicroService service)
        {
            FeatureInfo = featureInfo;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisableInfo = DisableInfo.Create().Value;
            MicroService = service;
        }

        public void Deactivate(DisableInfo disableInfo)
        {
            DisableInfo = disableInfo;
        }

        public void Activate()
        {
            DisableInfo.EmptyObject();
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
