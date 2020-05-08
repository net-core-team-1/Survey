using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Roles.Commands
{
    public class UnregisterRoleCommand : ICommand
    {
        public Guid Id { get; }
        public Guid DeletedBy { get; }
        public DateTime DeleteOn { get; }
        public string Reason { get; }

        public UnregisterRoleCommand(Guid id, Guid deletedBy, DateTime deleteOn, string reason)
        {
            Id = id;
            DeletedBy = deletedBy;
            DeleteOn = deleteOn;
            Reason = reason;
        }
    }
}
