using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class EditRoleCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public EditRoleCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
