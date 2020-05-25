using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;

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
