using Survey.Common.Messages;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

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
