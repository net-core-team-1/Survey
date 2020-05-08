using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class DisableRoleCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DisabledBy { get; }

        public DisableRoleCommand(Guid id, Guid disabledBy)
        {
            Id = id;
            DisabledBy = disabledBy;
        }
    }
}
