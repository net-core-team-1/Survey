using Survey.CQRS.Commands;
using Survey.CQRS.Messages;
using System;

namespace Survey.Api.Commands.Features
{
    [Message("transverse")]
    public sealed class DeactivateFeatureCommand : ICommand
    {
        public Guid Id { get;  }
        public Guid DisabledBy { get; }
        public DeactivateFeatureCommand(Guid id,Guid disabledBy)
        {
            Id = id;
            DisabledBy = disabledBy;
        }
    }
}
