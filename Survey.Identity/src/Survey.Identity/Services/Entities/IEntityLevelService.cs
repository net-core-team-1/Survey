using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Entities
{
    public interface IEntityLevelService
    {
        Task<Result> Create(Guid id, string name, string description, Guid? parentId, Guid createdBy);
        Task<Result> EditInfo(Guid id, string name, string description, Guid? parentId);

        Task<Result> Delete(Guid id, Guid by, string reason);



    }
}
