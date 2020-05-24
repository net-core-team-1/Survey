using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.RejectedEvents
{
    public class FeatureDisablingRejectedEvent : RejectedEventBase<DisableFeatureCommand>
    {
        public FeatureDisablingRejectedEvent() : base()
        {
        }
        private FeatureDisablingRejectedEvent(string reason, string code, DisableFeatureCommand command)
        : base(new FeatureIdEventKey(command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<DisableFeatureCommand> CreateFrom(string reason, string code, DisableFeatureCommand command)
        {
            return new FeatureDisablingRejectedEvent(reason, code, command);
        }
    }
}
