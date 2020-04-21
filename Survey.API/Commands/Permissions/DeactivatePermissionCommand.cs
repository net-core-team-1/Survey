using Survey.Common.Messages;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Api.Commands.Permissions
{
    [Message("transverse")]
    public sealed class DeactivatePermissionCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DisabledBy { get; }

        public DeactivatePermissionCommand(Guid id,Guid disabledBy)
        {
            Id = id;
            DisabledBy = disabledBy;
        }
    }
}
