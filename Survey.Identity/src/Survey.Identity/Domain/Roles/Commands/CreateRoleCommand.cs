using Survey.CQRS.Commands;
using Survey.Identity.Contracts.Features;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class CreateRoleCommand : ICommand
    {
        public string Name { get; }
        public Guid CreatedBy { get; }
        public List<Guid> Features { get; set; }


        public CreateRoleCommand(string name,  Guid createdBy, List<Guid> features = null)
        {
            Name = name;
            CreatedBy = createdBy;
            Features = features;
        }
    }
}
