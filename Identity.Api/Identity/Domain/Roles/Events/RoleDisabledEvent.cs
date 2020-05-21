﻿using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Domain.Roles.Events.EventKeys;
using Survey.Common.CQRS.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Events
{
    public class RoleDisabledEvent : AcceptedEventBase<DisableRoleCommand>
    {
        public Guid Id { get; }
        public Guid DisabledBy { get; }

        public RoleDisabledEvent(Guid id, Guid disabledBy)
            : base(new RoleIdEventKey(id))
        {
            Id = id;
            DisabledBy = disabledBy;
        }
        public RoleDisabledEvent() : base()
        {
        }

        public override IAcceptedEvent<DisableRoleCommand> CreateFrom(DisableRoleCommand command)
        {
            return new RoleDisabledEvent(command.Id, command.DisabledBy);
        }
    }
}