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
    public class UserEditionRejectedEvent : RejectedEventBase<EditUserCommand>
    {
        public UserEditionRejectedEvent() : base() { }
        private UserEditionRejectedEvent(string reason, string code, EditUserCommand command)
           : base(new UserIdEventKey(command.UserId), reason, code, command)
        {
        }
        public override IRejectedEvent<EditUserCommand> CreateFrom(string reason, string code, EditUserCommand command)
        {
            return new UserEditionRejectedEvent(reason, code, command);
        }
    }
}
