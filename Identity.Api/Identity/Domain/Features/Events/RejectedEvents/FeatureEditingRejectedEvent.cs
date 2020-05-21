using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.RejectedEvents
{
    public class FeatureEditingRejectedEvent : RejectedEventBase<EditFeatureCommand>
    {
        public FeatureEditingRejectedEvent() : base()
        {
        }
        private FeatureEditingRejectedEvent(string reason, string code, EditFeatureCommand command)
         : base(new FeatureIdEventKey(command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditFeatureCommand> CreateFrom(string reason, string code, EditFeatureCommand command)
        {
            return new FeatureEditingRejectedEvent(reason, code, command);
        }
    }
}
