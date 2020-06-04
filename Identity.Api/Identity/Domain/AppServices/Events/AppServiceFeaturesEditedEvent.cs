﻿using Identity.Api.Identity.Domain.AppServices.Commands;
using Identity.Api.Identity.Domain.AppServices.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.AppServices.Events
{
    public class AppServiceFeaturesEditedEvent : AcceptedEventBase<EditAppServiceFeaturesCommand>
    {
        public Guid AppServiceId { get; }
        public List<Guid> Features { get; }
        public AppServiceFeaturesEditedEvent() : base()
        {
        }

        public AppServiceFeaturesEditedEvent(Guid appServiceId, List<Guid> features)
            : this()
        {
            AppServiceId = appServiceId;
            Features = features;
        }

    }
}
