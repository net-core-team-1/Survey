using Common.Types.Types.Events;
using Identity.Api.Identity.Domain.Structures.Events;
using Microsoft.Extensions.DiagnosticAdapter.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures
{
    public class Structure : IDomainEntity
    {
        public virtual Guid Id { get; protected set; }
        public virtual StructureInfo StructureInfo { get; protected set; }
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual StructureUsersCollection StructureUsers { get; protected set; }
        public List<IEvent> Events { get; set; }

        protected Structure()
        {
            StructureUsers = new StructureUsersCollection();
            Events = new List<IEvent>();
        }

        public Structure(StructureInfo structureInfo, CreateInfo createInfo)
            :this()
        {
            Id = Guid.NewGuid();
            StructureInfo = structureInfo;
            CreateInfo = createInfo;
            DisableInfo = DisabeleInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
            Events.Add(new StructureRegistredEvent(structureInfo.Name, structureInfo.Description, createInfo.CreatedBy.Value));
        }

        public void Disable(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
            Events.Add(new StructureDisabledEvent(this.Id, disableInfo.DisabledBy.Value));
        }

        internal void EditInfo(StructureInfo structureInfo)
        {
            StructureInfo = structureInfo;
            Events.Add(new StructureEditedEvent(this.Id, structureInfo.Name, structureInfo.Description));
        }

        public void Remove(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
            Events.Add(new StructureDeletedEvent(this.Id, deleteInfo.DeleteReason, deleteInfo.DeletedBy.Value));
        }

        internal void EditUsers(Guid assignedBy, List<Guid> users)
        {
            var toAdd = users.Where(f => StructureUsers.Where(x => x.UserId == f).Count() == 0)
                               .Select(s => new StructureUsers(this.Id, s))
                               .ToList();

            var toRemove = StructureUsers.Where(f => users.Where(x => x == f.UserId).Count() == 0)
                                      .Select(s => new StructureUsers(this.Id, s.UserId))
                                      .ToList();

            StructureUsers.AddRange(toAdd);
            StructureUsers.RemoveRange(toRemove);
            Events.Add(new StructureUsersEditedEvent(this.Id, assignedBy, users));
        }
        public void RegisterUser(StructureUsers structureUser)
        {
            StructureUsers.Add(structureUser);
            Events.Add(new StructureUsersRegistredEvent(this.Id, structureUser.StructureId));
        }
        public void UnregisterUser(StructureUsers structureUser)
        {
            StructureUsers.Remove(structureUser);
            Events.Add(new StructureUsersUnregistredEvent(this.Id, structureUser.UserId));
        }
    }
}
