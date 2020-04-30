using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Features.Commands
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
