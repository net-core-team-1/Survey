using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Indentity.Domain.Roles.Commands
{
    public sealed class RemoveRoleCommand : ICommand
    {
        public Guid Id { get; }
        public string Reason { get; }
        public Guid By { get; }
        public RemoveRoleCommand(Guid id, Guid by,string reason)
        {
            Id = id;
            Reason = reason;
            By = by;
        }
    }
}
