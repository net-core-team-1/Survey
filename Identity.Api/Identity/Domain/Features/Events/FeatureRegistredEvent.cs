using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events
{
    public class FeatureRegistredEvent : AcceptedEventBase<RegisterFeatureCommand>
    {
        public string Label { get; }
        public string Description { get; }
        public string ControllerName { get; }
        public string ControllerActionName { get; }
        public string Action { get; }
        public Guid CreatedBy { get; }
        public Guid AppServiceId { get; }
        public FeatureRegistredEvent() : base()
        {
        }

        public FeatureRegistredEvent(string label, string description, string controllerName,
            string controllerActionName, string action, Guid createdBy, Guid appServiceId)
            : this()
        {
            Label = label;
            Description = description;
            ControllerName = controllerName;
            ControllerActionName = controllerActionName;
            Action = action;
            CreatedBy = createdBy;
            AppServiceId = appServiceId;
        }
    }
}
