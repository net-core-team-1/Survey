using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class CreateRoleCommand : ICommand
    {
        public string Name { get; }
        public Guid CreatedBy { get; }
        public List<Guid> Features { get; }


        public CreateRoleCommand(string name,  Guid createdBy, List<Guid> features = null)
        {
            Name = name;
            CreatedBy = createdBy;
            Features = features;
        }
    }
}
