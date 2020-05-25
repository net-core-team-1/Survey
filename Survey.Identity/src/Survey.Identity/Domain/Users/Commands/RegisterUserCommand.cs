using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Users.Commands
{
    public sealed class RegisterUserCommand : ICommand
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }
        public Guid EntityId { get;  }

        public List<Guid> Roles { get; }
        public RegisterUserCommand(string firstName, string lastName, string email, string password,Guid entityId,List<Guid> roles=null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Roles = roles;
            EntityId = entityId;
        }
    }
}
