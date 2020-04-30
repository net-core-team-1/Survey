using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Roles.Commands
{
    public sealed class EditRoleCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        public List<Guid> Features { get; }
        public bool DeleteExistingFeatures { get; }

        public EditRoleCommand(Guid id, string name, string description, List<Guid> features = null,
                                     bool deleteExisting = false)
        {
            Id = id;
            Name = name;
            Description = description;
            DeleteExistingFeatures = deleteExisting;
            Features = features;
        }
    }
}
