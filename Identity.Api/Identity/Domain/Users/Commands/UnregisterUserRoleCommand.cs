using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class UnregisterUserRoleCommand : ICommand
    {
        public Guid UserId { get; }
        public Guid RoleId { get; }

        public UnregisterUserRoleCommand(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
    }
}
