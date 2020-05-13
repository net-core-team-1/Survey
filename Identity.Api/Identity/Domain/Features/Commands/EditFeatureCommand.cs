using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Commands
{
    public class EditFeatureCommand : ICommand
    {
        public Guid FeatureId { get; }
        public string Label { get; }
        public string Description { get; }
        public string ControllerName { get; }
        public string ControllerActionName { get; }
        public string Action { get; }
        public Guid AppServiceId { get; }

        public EditFeatureCommand(Guid featureId, string label, string description, 
            string controllerName, string controllerActionName, string action, Guid appServiceId)
        {
            FeatureId = featureId;
            Label = label;
            Description = description;
            ControllerName = controllerName;
            ControllerActionName = controllerActionName;
            Action = action;
            AppServiceId = appServiceId;
        }
    }
}
