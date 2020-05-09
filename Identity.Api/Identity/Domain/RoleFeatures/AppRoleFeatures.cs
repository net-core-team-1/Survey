using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.RoleFeatures
{
    public class AppRoleFeatures
    {
        public Guid Id { get; protected set; }
        public virtual AppRole Role { get; protected set; }
        public virtual Feature Feature { get; protected set; }
        public Guid RoleId { get; protected set; }
        public Guid FeatureId { get; protected set; }
        public DateTime AssignedOn { get; protected set; }
        public Guid AssignedBy { get; protected set; }

        protected AppRoleFeatures()
        {

        }
        public AppRoleFeatures(Guid roleId, Guid featureId, DateTime assignedOn, Guid assignedBy)
        {
            Id = Guid.NewGuid();
            RoleId = roleId;
            FeatureId = featureId;
            //Role = new AppRole(roleId);
            //Feature = new Feature(featureId);
            AssignedOn = assignedOn;
            AssignedBy = assignedBy;
        }

        public AppRoleFeatures(AppRole role, Feature feature, DateTime assignedOn, Guid assignedBy)
        {
            Id = Guid.NewGuid();
            Role = role;
            Feature = feature;
            RoleId = role.Id;
            FeatureId = feature.Id;
            AssignedOn = assignedOn;
            AssignedBy = assignedBy;
        }
    }
}
