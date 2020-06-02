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
            : base(new FeatureIdEventKey(featureId))
        {
            FeatureId = featureId;
            DisabledBy = disabledBy;
        }

        public override IAcceptedEvent<DisableFeatureCommand> CreateFrom(DisableFeatureCommand command)
        {
            return new FeatureDisabledEvent(command.FeatureId, command.DisabledBy, command.Reason);
        }
    }
}
