using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;

namespace Survey.Api.Commands.Permissions
{
    [Message("transverse")]
    public sealed class RemovePermissionCommand : ICommand
    {
        public Guid Id { get; }
        public string Reason { get; }
        public Guid By { get; }
        public RemovePermissionCommand(Guid id, Guid by,string reason)
        {
            Id = id;
            Reason = reason;
            By = by;
        }
    }
}
