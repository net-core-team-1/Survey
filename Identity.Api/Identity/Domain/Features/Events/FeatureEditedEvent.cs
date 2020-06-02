using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events
{
    public class FeatureEditedEvent : AcceptedEventBase<EditFeatureCommand>
    {
        public Guid FeatureId { get; }
        public string Label { get; }
        public string Description { get; }
        public string ControllerName { get; }
        public string ControllerActionName { get; }
        public string Action { get; }
        public FeatureEditedEvent() : base()
        {
        }

        public FeatureEditedEvent(Guid featureId, string label, string description, string controllerName
            , string controllerActionName, string action)
            : base(new FeatureIdEventKey(featureId))
        {
            FeatureId = featureId;
            Label = label;
            Description = description;
            ControllerName = controllerName;
            ControllerActionName = controllerActionName;
            Action = action;
        }

    }
}
