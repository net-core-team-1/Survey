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
    public class UserRegistrationRejectedEvent : RejectedEventBase<RegisterUserCommand>
    {
        public UserRegistrationRejectedEvent() : base() { }
        private UserRegistrationRejectedEvent(string reason, string code, RegisterUserCommand command)
            : base(new UserNameEventKey(command.UserName), reason, code, command)
        {
        }
        public override IRejectedEvent<RegisterUserCommand> CreateFrom(string reason, string code, RegisterUserCommand command)
        {
            return new UserRegistrationRejectedEvent(reason, code, command);
        }
    }
}
