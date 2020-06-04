using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events
{
    public class FeatureDisabledEvent : AcceptedEventBase<DisableFeatureCommand>
    {
        public Guid FeatureId { get; }
        public Guid DisabledBy { get; }
        public FeatureDisabledEvent() : base()
        {
        }

        public FeatureDisabledEvent(Guid featureId, Guid disabledBy)
            : this()
        {
            FeatureId = featureId;
            DisabledBy = disabledBy;
        }

    }
}
