using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;

namespace Survey.Api.Commands.Features
{
    [Message("transverse")]
    public sealed class RemoveFeatureCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DeletedBy { get; }
        public string Reason { get; }

        public RemoveFeatureCommand(Guid id, Guid deletedBy, string reason)
        {
            Id = id;
            DeletedBy = deletedBy;
            Reason = reason;
        }
    }
}
