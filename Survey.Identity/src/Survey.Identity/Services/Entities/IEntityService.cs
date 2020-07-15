using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Entities
{
    public interface IEntityService
    {
        Task<Result> Create(string name,string description, Guid? createdBy);
        Task<Result> EditInfo(Guid id, string name, string description);

        Task<Result> Delete(Guid id,Guid by,string reason);

    }
}
