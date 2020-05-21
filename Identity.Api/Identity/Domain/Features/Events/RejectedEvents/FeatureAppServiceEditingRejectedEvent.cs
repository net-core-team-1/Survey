using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.RejectedEvents
{
    public class FeatureAppServiceEditingRejectedEvent : RejectedEventBase<EditFeatureAppServiceCommand>
    {
        public FeatureAppServiceEditingRejectedEvent() : base()
        {
        }
        private FeatureAppServiceEditingRejectedEvent(string reason, string code, EditFeatureAppServiceCommand command)
         : base(new FeatureIdEventKey(command.FeatureId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditFeatureAppServiceCommand> CreateFrom(string reason, string code, EditFeatureAppServiceCommand command)
        {
            return new FeatureAppServiceEditingRejectedEvent(reason, code, command);
        }
    }
}
