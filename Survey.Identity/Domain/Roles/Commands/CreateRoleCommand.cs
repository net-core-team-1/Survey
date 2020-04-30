using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Domain.Roles.Commands
{
    public sealed class CreateRoleCommand : ICommand
    {
        public string Name { get; }
        public string Description { get; }
        public Guid CreatedBy { get; }
        public List<Guid> Features { get; }


        public CreateRoleCommand(string name, string description, Guid createdBy, List<Guid> features = null)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            Features = features;
        }
    }
}
