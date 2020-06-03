using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Features.Events;
using Identity.Api.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Features
{
    public class Feature : IDomainEntity
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
        public List<IEvent> Events { get; set; }

        protected Feature()
        {
            RoleFeatures = new AppRoleFeaturesCollection();
            Events = new List<IEvent>();
        }
        public Feature(Guid featureId, Guid serviceId)
        {
            this.Id = featureId;
            this.ServiceId = serviceId;
        }
        public Feature(FeatureInfo featureInfo, CreateInfo creationInfo, AppService appService)
            : this()
        {
            Id = Guid.NewGuid();
            FeatureInfo = featureInfo;
            CreateInfo = creationInfo;
            DeleteInfo = DeleteInfo.Create().Value;
            DisabeleInfo = DisabeleInfo.Create().Value;
            Service = appService;
            Events.Add(new FeatureRegistredEvent(featureInfo.Label, featureInfo.Description, featureInfo.Controller,
                featureInfo.ControllerActionName, featureInfo.Action, creationInfo.CreatedBy.Value, appService.Id));
        }

        internal void ChangeService(AppService appService)
        {
            Service = appService;
            Events.Add(new FeatureAppServiceEditedEvent(appService.Id, this.Id));
        }

        public void Deactivate(DisabeleInfo disableInfo)
        {
            DisabeleInfo = disableInfo;
            Events.Add(new FeatureDisabledEvent(this.Id, disableInfo.DisabledBy.Value));
        }

        public void UpdateInfo(FeatureInfo featureInfo)
        {
            FeatureInfo = featureInfo;
            Events.Add(new FeatureEditedEvent(this.Id, featureInfo.Label, featureInfo.Description, featureInfo.Controller,
                featureInfo.ControllerActionName, featureInfo.Action));
        }

        public void Remove(DeleteInfo deletionObj)
        {
            DeleteInfo = deletionObj;
            Events.Add(new FeatureUnregistredEvent(this.Id, deletionObj.DeletedBy.Value, deletionObj.DeleteReason));
        }
    }
}
