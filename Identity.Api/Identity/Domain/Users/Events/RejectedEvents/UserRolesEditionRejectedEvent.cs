using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events.EventKeys;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events.RejectedEvents
{
    public class UserRolesEditionRejectedEvent : RejectedEventBase<EditUserRolesCommad>
    {
        public UserRolesEditionRejectedEvent() : base() { }
        private UserRolesEditionRejectedEvent(string reason, string code, EditUserRolesCommad command)
             : base(new UserIdEventKey(command.UserId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditUserRolesCommad> CreateFrom(string reason, string code, EditUserRolesCommad command)
        {
            return new UserRolesEditionRejectedEvent(reason, code, command);
        }
    }
}
