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
        public AppRoleFeatures(Guid roleId, Guid featureId)
        {
            RoleId = roleId;
            FeatureId = featureId;
        }
        public AppRoleFeatures(AppRole role, Feature feature)
            : this(role.Id, feature.Id)
        {
            Role = role;
            Feature = feature;
        }
    }
}
