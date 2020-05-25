using Survey.CQRS.Commands;
using System;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class ActivateRoleCommand : ICommand
    {
        public Guid Id { get; }

        public ActivateRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
