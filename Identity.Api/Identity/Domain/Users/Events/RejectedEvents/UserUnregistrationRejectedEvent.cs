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
    public class UserUnregistrationRejectedEvent : RejectedEventBase<UnregisterUserCommand>
    {
        public UserUnregistrationRejectedEvent() : base() { }
        private UserUnregistrationRejectedEvent(string reason, string code, UnregisterUserCommand command)
             : base(new UserIdEventKey(command.UserId), reason, code, command)
        {
        }
        public override IRejectedEvent<UnregisterUserCommand> CreateFrom(string reason, string code, UnregisterUserCommand command)
        {
            return new UserUnregistrationRejectedEvent(reason, code, command);
        }
    }
}
