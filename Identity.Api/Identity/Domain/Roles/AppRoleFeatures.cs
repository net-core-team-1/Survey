using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.RoleFeature
{
    public class AppRoleFeatures
    {
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual Guid RoleId { get; protected set; }
        public virtual AppRole Role { get; protected set; }
        public virtual Guid FeatureId { get; protected set; }
        public virtual Feature Feature { get; protected set; }

        public AppRoleFeatures() { }
        public AppRoleFeatures(Guid roleId, Guid featureId, Guid createdBy)
        {
            RoleId = roleId;
            FeatureId = featureId;
            CreateInfo = CreateInfo.Create(createdBy).Value;
        }
        public AppRoleFeatures(AppRole role, Feature feature, Guid createdBy)
            : this(role.Id, feature.Id, createdBy)
        {
            Role = role;
            Feature = feature;
        }
    }
}
