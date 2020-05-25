using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Identity.Domain.Features.Commands
{
    public sealed class ActivateFeatureCommand : ICommand
    {
        public Guid Id { get;  }
        public ActivateFeatureCommand(Guid id)
        {
            Id = id;
        }
    }
}
