using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events
{
    public class AppServiceRegistredEvent : AcceptedEventBase<RegisterAppServiceCommand>
    {
        public Guid AppServiceId { get; }
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }

        public AppServiceRegistredEvent():base() { }
        public AppServiceRegistredEvent(Guid appServiceId, string name, string description, Guid createdBy)
            : this()
        {
            AppServiceId = appServiceId;
            Name = name;
            Description = description;
            CreatedBy = createdBy;
        }

    }
}
