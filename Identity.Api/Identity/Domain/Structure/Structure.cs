using Microsoft.Extensions.DiagnosticAdapter.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Identity.Domain.Structure
{
    public class Structure
    {
        public virtual Guid Id { get; protected set; }
        public virtual StructureInfo StructureInfo { get; protected set; }
        public virtual CreateInfo CreateInfo { get; protected set; }
        public virtual DisabeleInfo DisableInfo { get; protected set; }
        public virtual DeleteInfo DeleteInfo { get; protected set; }
        public virtual StructureUsersCollection StructureUsers { get; protected set; }

        protected Structure() { }

        public Structure(StructureInfo structureInfo, CreateInfo createInfo)
        {
            Id = Guid.NewGuid();
            StructureInfo = structureInfo;
            CreateInfo = createInfo;
            DisableInfo = DisabeleInfo.Create().Value;
            DeleteInfo = DeleteInfo.Create().Value;
        }

        public void DisableService(DisabeleInfo disableInfo)
        {
            DisableInfo = disableInfo;
        }

        internal void EditInfo(StructureInfo structureInfo)
        {
            StructureInfo = structureInfo;
        }

        public void RemoveService(DeleteInfo deleteInfo)
        {
            DeleteInfo = deleteInfo;
        }

        public void RegisterFeature(StructureUsers structureUser)
        {

        }
        public void UnregisterFeature(StructureUsers structureUser)
        {

        }
        public void ClearFeatures()
        {

        }
    }
}
