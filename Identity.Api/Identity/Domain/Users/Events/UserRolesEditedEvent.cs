﻿using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserRolesEditedEvent : AcceptedEventBase<EditUserRolesCommad>
    {
        public Guid UserId { get; }
        public List<Guid> Roles { get; }

        public UserRolesEditedEvent(Guid userId, List<Guid> roles)
            : base(new UserIdEventKey(userId))
        {
            UserId = userId;
            Roles = roles;
        }

        public UserRolesEditedEvent() : base() { }

        public override IAcceptedEvent<EditUserRolesCommad> CreateFrom(EditUserRolesCommad command)
        {
            return new UserRolesEditedEvent(command.UserId, command.Roles);
        }
    }
}