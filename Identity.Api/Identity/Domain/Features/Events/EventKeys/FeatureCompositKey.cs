using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events.EventKeys
{
    public class FeatureCompositKey : IEventKey
    {
        public string Key { get; }
        public string KeyDescription { get; }

        public FeatureCompositKey(string name, string controllerName, string ControllerActionName, string action, Guid serviceId)
        {
            Key = $"{name}_{controllerName}_{ControllerActionName}_{action}_{serviceId.ToString()}";
            KeyDescription = "Name_ControllerName_ControllerActionName_action_serviceId";
        }
    }
}
