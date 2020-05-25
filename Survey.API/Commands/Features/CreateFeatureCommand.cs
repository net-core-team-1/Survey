using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;

namespace Survey.Api.Commands.Features
{
    [Message("transverse")]
    public sealed class CreateFeatureCommand : ICommand
    {
        public string Label { get; }
        public string Description { get; }
        public string Action { get; }
        public string Controller { get; }
        public string ControllerActionName { get; }
        public Guid CreatedBy { get; }
        public CreateFeatureCommand(string label, string description, string action, string controller,
                                 string controllerActionNmae, Guid createdBy)
        {
            Label = label;
            Description = description;
            Action = action;
            Controller = controller;
            ControllerActionName = controllerActionNmae;
            CreatedBy = createdBy;
        }
    }
}
