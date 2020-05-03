using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class EditUserCommand : ICommand
    {
        public Guid UserId { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int CivilityId { get; }

        public EditUserCommand(Guid userId, string firstName, string lastName, int civilityId)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            CivilityId = civilityId;
        }
    }
}
