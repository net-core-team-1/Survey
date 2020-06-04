using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events
{
    public class FeatureUnregistredEvent : AcceptedEventBase<UnRegisterFeatureCommand>
    {
        public Guid FeatureId { get; }
        public Guid DeletedBy { get; }
        public String Reason { get; }
        public FeatureUnregistredEvent() : base()
        {
        }
        public FeatureUnregistredEvent(Guid featureId, Guid deletedBy, string reason)
            : this()
        {
            FeatureId = featureId;
            DeletedBy = deletedBy;
            Reason = reason;
        }

    }
}
