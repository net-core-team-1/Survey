using Survey.Identity.Domain.Features;
using System;

namespace Survey.Identity.Domain.Roles
{
    public class RoleFeature
    {
        public Guid RoleId { get; set; }
        public Guid FeatureId { get; set; }
        public byte[] Timestamp { get; private set; }

        public DateTime AssociatedOn { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Role Role { get; set; }

        private RoleFeature(Guid roleId, Guid featureId)
        {
            RoleId = roleId;
            FeatureId = featureId;
            AssociatedOn = DateTime.Now;
        }
        protected RoleFeature()
        {

        }
        public static RoleFeature Create(Guid roleId,Guid featureId)
        {
            var roleFeature = new RoleFeature(roleId, featureId);
            return roleFeature;
        }
    }
}
