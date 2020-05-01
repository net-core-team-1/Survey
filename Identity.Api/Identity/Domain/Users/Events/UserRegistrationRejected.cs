using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Users.Commands;
using Survey.Common.CQRS.Events;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Events
{
    public class UserRegistrationRejected : IRejectedEvent<RegisterUserCommand>
    {
        public string UserName { get; }

        public string Reason { get; }
        public string Code { get; }

        public UserRegistrationRejected() { }
        private UserRegistrationRejected(string userName, string reason, string code)
        {
            UserName = userName;
            Reason = reason;
            Code = code;
        }

        public IRejectedEvent<RegisterUserCommand> CreateFrom(RegisterUserCommand command, string reason, string code)
        {
            return new UserRegistrationRejected(command.UserName, reason, code);
        }
    }
}
