using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class EditRoleCommand : ICommand
    {
        public Guid Id { get; }
        public string Name { get; }


        public EditRoleCommand(Guid id, string name)
        {
            Id = id;
            Name = name;

        }
    }
}
