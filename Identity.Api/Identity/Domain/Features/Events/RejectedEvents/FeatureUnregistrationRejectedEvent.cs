using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.RejectedEvents
{
    public class FeatureUnregistrationRejectedEvent : RejectedEventBase<UnRegisterFeatureCommand>
    {
        public FeatureUnregistrationRejectedEvent() : base()
        {
        }
        private FeatureUnregistrationRejectedEvent(string reason, string code, UnRegisterFeatureCommand command)
        : base(new FeatureIdEventKey(command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<UnRegisterFeatureCommand> CreateFrom(string reason, string code, UnRegisterFeatureCommand command)
        {
            return new FeatureUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
