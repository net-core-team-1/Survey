using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Features.Commands
{
    public sealed class CreateFeatureCommand : ICommand
    {
        public string Label { get; }
        public string Description { get; }
        public string Action { get; }
        public string Controller { get; }
        public string ControllerActionName { get; }
        public Guid CreatedBy { get; }
        public Guid MicroServiceId { get; set; }

        public CreateFeatureCommand(string label, string description, string action, string controller,
                                 string controllerActionName, Guid createdBy,Guid microServiceId)
        {
            Label = label;
            Description = description;
            Action = action;
            Controller = controller;
            ControllerActionName = controllerActionName;
            CreatedBy = createdBy;
            MicroServiceId = microServiceId;
        }
    }
}
