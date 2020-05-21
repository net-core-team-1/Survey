using Survey.Common.Types;
using Survey.Common.Utils.CustomAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class RegisterUserCommand : ICommand
    {
        public string UserName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public int CivilityId { get; }
        public Guid StructureId { get; }
        public List<Guid> Permissions { get; }

        [FieldAnonymizer("******")]
        private string password;
        public string Password { get { return password; } }

        public RegisterUserCommand(
            string userName,
            string firstName, string lastName, string email,
            string password, int civilityId, List<Guid> permissions, Guid structureId)
        {
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            this.password = password;
            CivilityId = civilityId;
            Permissions = permissions;
            StructureId = structureId;
        }
    }
}
