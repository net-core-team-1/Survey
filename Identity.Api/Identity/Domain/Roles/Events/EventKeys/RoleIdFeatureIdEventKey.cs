using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events.EventKeys
{
    public class RoleIdFeatureIdEventKey:IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public RoleIdFeatureIdEventKey(Guid userId, Guid featureId)
        {
            Key = $"{userId.ToString()}_{featureId.ToString()}";
            KeyDescription = "UserId_FeatureId";
        }
    }
}
