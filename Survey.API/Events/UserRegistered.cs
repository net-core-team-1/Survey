using Common.Types.Types.Events;
using Survey.Common.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Api.Events
{
    [Message("transverse")]
    public sealed class UserRegistered:IEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public UserRegistered(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
