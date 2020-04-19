using Survey.Common.Types;
using Survey.Transverse.Domain.Permissions;
using System;
using System.Collections.Generic;

namespace Survey.Transverse.Domain.Features
{
    public class Feature : BaseEntity
    {
        public virtual FeatureInfo FeatureInfo { get; private set; }
        public virtual CreateInfo CreateInfo { get; private set; }
        public virtual DisabeleInfo DisabeleInfo { get; private set; }
        public virtual DeleteInfo DeleteInfo { get; private set; }


        protected Feature()
        {

        }
        public Feature(FeatureInfo featureInfo, CreateInfo creationInfo)
        {
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
