using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Users.Commands
{
    public class UnregisterUserCommand : ICommand
    {
        public Guid UserId { get; }
        public string Reason { get; }
        public Guid DeletedBy { get; }
        public DateTime DeletedAt { get; }

        public UnregisterUserCommand(Guid userId, string reason, Guid deletedBy, DateTime deletedAt)
        {
            UserId = userId;
            Reason = reason;
            DeletedBy = deletedBy;
            DeletedAt = deletedAt;
        }
    }
}
