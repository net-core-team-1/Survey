using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.RoleFeature;
using Identity.Api.Identity.Domain.Roles.Events;
using Identity.Api.Identity.Domain.Structures;
using Identity.Api.Identity.Domain.Structures.Events.EventKeys;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Identity.Api.Identity.Domain.Roles
{
    public class AppRole : IdentityRole<Guid>, IDomainEntity
    {
        public virtual string Description { get; set; }
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual Guid ServiceId { get; private set; }
        public virtual AppService Service { get; private set; }
        public virtual AppRoleFeaturesCollection RoleFeatures { get; protected set; }
        public virtual Guid StructureId { get; protected set; }
        public virtual Structure Structure { get; protected set; }
        public List<IEvent> Events { get; set; }

        protected AppRole()
        {
            RoleFeatures = new AppRoleFeaturesCollection();
            Events = new List<IEvent>();
        }

        public AppRole(Guid roleId)
          : this()
        {
            this.Id = roleId;
        }

        public AppRole(CreateInfo createInfo, string roleName, string description, Guid serviceId, Guid structureId)
            : this()
        {
            this.Name = roleName;
            this.NormalizedName = roleName.ToUpper();
            this.Description = description;
            CreateInfo = createInfo;
            DisableInfo = DisabeleInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            this.ServiceId = serviceId;
            this.StructureId = structureId;
            Events.Add(new RoleRegistredEvent(roleName, description, createInfo.CreatedBy.Value, serviceId, structureId));
        }

        internal void Disable(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
            Events.Add(new RoleDisabledEvent(this.Id, disableInfo.DisabledBy.Value));
        }

        internal void Unregister(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
            Events.Add(new RoleUnregistredEvent(this.Id, deleteInfo.DeletedBy.Value
                , deleteInfo.DeletedOn.Value, deleteInfo.DeleteReason));
        }

        public void EditRoleInfo(string name, string description, AppService appService)
        {
            this.Name = name;
            this.NormalizedName = name.ToUpper();
            this.Description = description;
            this.Service = appService;
            Events.Add(new RoleEditedEvent(this.Id, name, description, appService.Id));
        }

        public void EditFeatures(Guid createdby, List<Feature> features)
        {
            var toAdd = features.Where(f => RoleFeatures.Where(x => x.Feature.Id == f.Id).Count() == 0)
                                            .Select(s => new AppRoleFeatures(this, s, createdby))
                                            .ToList();

            var toRemove = RoleFeatures.Where(f => features.Where(x => x.Id == f.FeatureId).Count() == 0)
                                            .Select(s => new AppRoleFeatures(this.Id, s.FeatureId, createdby))
                                            .ToList();


            RoleFeatures.AddRange(toAdd);
            RoleFeatures.RemoveRange(toRemove);
            Events.Add(new RoleFeatureEditedEvent(createdby, this.Id, features.Select(x => x.Id).ToList()));

        }
        internal void AssignFeature(Guid CreatedBy, Guid featureId)
        {
            RoleFeatures.Add(new AppRoleFeatures(this.Id, featureId, CreatedBy));
            Events.Add(new RoleFeatureRegistredEvent(this.Id, featureId, CreatedBy));
        }

        internal void RemoveFeature(Guid featureId)
        {
            RoleFeatures.Remove(new AppRoleFeatures(this.Id, featureId));
            Events.Add(new RoleFeatureUnregistredEvent(this.Id, featureId));
        }

    }
}
