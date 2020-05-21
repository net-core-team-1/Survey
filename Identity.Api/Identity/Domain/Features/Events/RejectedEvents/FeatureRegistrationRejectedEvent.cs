using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.RejectedEvents
{
    public class FeatureRegistrationRejectedEvent : RejectedEventBase<RegisterFeatureCommand>
    {
        public FeatureRegistrationRejectedEvent() : base()
        {
        }
        private FeatureRegistrationRejectedEvent(string reason, string code, RegisterFeatureCommand command)
         : base(new FeatureCompositKey(command.Label, command.ControllerName,
             command.ControllerActionName, command.Action, command.AppServiceId), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterFeatureCommand> CreateFrom(string reason, string code, RegisterFeatureCommand command)
        {
            return new FeatureRegistrationRejectedEvent(reason, code, command);
        }
    }
}
