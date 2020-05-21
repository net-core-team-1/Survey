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
        public Guid AppServiceId { get; }
        public FeatureEditedEvent() : base()
        {
        }

        private FeatureEditedEvent(Guid featureId, string label, string description, string controllerName
            , string controllerActionName, string action, Guid appServiceId)
            : base(new FeatureIdEventKey(featureId))
        {
            FeatureId = featureId;
            Label = label;
            Description = description;
            ControllerName = controllerName;
            ControllerActionName = controllerActionName;
            Action = action;
            AppServiceId = appServiceId;
        }

        public override IAcceptedEvent<EditFeatureCommand> CreateFrom(EditFeatureCommand command)
        {
            return new FeatureEditedEvent(command.FeatureId, command.Label, command.Description, command.ControllerName,
                command.ControllerActionName, command.Action, command.AppServiceId);
        }
    }
}
