﻿using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Identity.Domain.Features.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Features.Events
{
    public class FeatureAppServiceEditedEvent : AcceptedEventBase<EditFeatureAppServiceCommand>
    {
        public Guid AppServiceId { get; }
        public Guid FeatureId { get; }
        public FeatureAppServiceEditedEvent() : base()
        {
        }

        private FeatureAppServiceEditedEvent(Guid appServiceId, Guid featureId)
            : base(new FeatureIdEventKey(featureId))
        {
            AppServiceId = appServiceId;
            FeatureId = featureId;
        }

        public override IAcceptedEvent<EditFeatureAppServiceCommand> CreateFrom(EditFeatureAppServiceCommand command)
        {
            return new FeatureAppServiceEditedEvent(command.AppServiceId, command.FeatureId);
        }
    }
}