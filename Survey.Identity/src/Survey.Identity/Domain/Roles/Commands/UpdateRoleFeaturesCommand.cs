using Survey.CQRS.Commands;
using System;
using System.Collections.Generic;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class UpdateRoleFeaturesCommand : ICommand
    {
        public Guid Id { get; }
        public List<Guid> Features { get; set; }


        public UpdateRoleFeaturesCommand(Guid id, List<Guid> features = null)
        {
            Id = id;
            Features = features;
        }
    }
}
