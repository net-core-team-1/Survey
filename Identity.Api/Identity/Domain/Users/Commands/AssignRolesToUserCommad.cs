using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class AssignRolesToUserCommad : ICommand
    {
        public Guid UserId { get; }
        public List<Guid> Roles { get; }

        public AssignRolesToUserCommad(Guid userId, List<Guid> roles)
        {
            UserId = userId;
            Roles = roles;
        }
    }
}
