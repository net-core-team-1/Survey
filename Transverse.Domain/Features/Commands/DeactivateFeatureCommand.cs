using Survey.CQRS.Commands;
using System;

namespace Survey.Transverse.Domain.Features.Commands
{
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
