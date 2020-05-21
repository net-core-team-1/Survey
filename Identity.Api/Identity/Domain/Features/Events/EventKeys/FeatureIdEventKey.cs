using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.EventKeys
{
    public class FeatureIdEventKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public FeatureIdEventKey(Guid featureId)
        {
            Key = featureId.ToString();
            KeyDescription = "FeatureId";
        }
    }
}
