using Common.Types.Types.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Transverse.Domain.Users.Events
{
    public sealed class UserRegistered : IEvent
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public UserRegistered(string firstName,string lastName,string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
