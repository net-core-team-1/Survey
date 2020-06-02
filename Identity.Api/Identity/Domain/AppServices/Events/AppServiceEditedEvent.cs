using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events
{
    public class AppServiceEditedEvent : AcceptedEventBase<EditAppServiceCommand>
    {
        public Guid AppServiceId { get; }
        public string Name { get; }
        public string Description { get; }

        public AppServiceEditedEvent()
        {

        }
        public AppServiceEditedEvent(Guid appServiceId, string name, string description)
            : base(new AppServiceIdKey(appServiceId))
        {
            AppServiceId = appServiceId;
            Name = name;
            Description = description;
        }

    }
}
