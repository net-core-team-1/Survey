using Microsoft.Extensions.DiagnosticAdapter.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structures
{
    public class Structure
    {
        public virtual Guid Id { get; protected set; }
        public virtual StructureInfo StructureInfo { get; protected set; }
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual StructureUsersCollection StructureUsers { get; protected set; }

        protected Structure() { StructureUsers = new StructureUsersCollection(); }

        public Structure(StructureInfo structureInfo, CreateInfo createInfo)
        {
            Id = Guid.NewGuid();
            StructureInfo = structureInfo;
            CreateInfo = createInfo;
            DisableInfo = DisabeleInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
        }

        public void Disable(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
        }

        internal void EditInfo(StructureInfo structureInfo)
        {
            StructureInfo = structureInfo;
        }

        public void Remove(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
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
        }

        public void UnregisterRegister(StructureUsers structureUser)
        {
            StructureUsers.Remove(structureUser);
        }
        public void RegisterUser(StructureUsers structureUser)
        {
            StructureUsers.Add(structureUser);
        }
        public void ClearFeatures()
        {

        }
    }
}
