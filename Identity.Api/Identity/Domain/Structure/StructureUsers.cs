using Identity.Api.Identity.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure
{
    public class StructureUsers
    {
        public virtual Guid StructureId { get; protected set; }
        public virtual Guid UserId { get; protected set; }
        public virtual Structure Structure { get; protected set; }
        public virtual AppUser User { get; protected set; }
        protected StructureUsers() { }
        public StructureUsers(Guid structureId, Guid userId)
        {
            StructureId = structureId;
            UserId = userId;
        }

        public StructureUsers(Guid structureId, Guid userId, Structure structure, AppUser user)
            : this(structureId, userId)
        {
            Structure = structure;
            User = user;
        }
    }
}
