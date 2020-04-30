using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Roles.Commands
{
    public sealed class DeactivateRoleCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DisabledBy { get; }

        public DeactivateRoleCommand(Guid id,Guid disabledBy)
        {
            Id = id;
            DisabledBy = disabledBy;
        }
    }
}
