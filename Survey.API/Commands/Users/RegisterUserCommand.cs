using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;
using System.Collections.Generic;

namespace Survey.Api.Commands.Users
{
    [Message("transverse")]

    public sealed class RegisterUserCommand : ICommand
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Password { get; }

        public List<Guid> Permissions { get; }
        public RegisterUserCommand(string firstName, string lastName, string email, string password,List<Guid> permissions=null)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Permissions = permissions;
        }
    }
}
