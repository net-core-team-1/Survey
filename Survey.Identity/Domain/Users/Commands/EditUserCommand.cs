using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Users.Commands
{
    public sealed class EditUserInfoCommand : ICommand
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public List<Guid> Roles { get; }
        public EditUserInfoCommand(Guid id,string firstName,string lastName,
                               List<Guid> roles=null)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Roles = roles;
        }
    }
}
