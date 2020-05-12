using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Roles
{
    public interface IRoleService
    {
        Task<Result> Create(string name, Guid by, List<Guid> features);
        Task<Result> EditName(Guid id,string name);
        Task<Result> UpdateFeatures(Guid id, List<Guid> features);
        Task<Result> Deactivate(Guid id, Guid by);
        Task<Result> Remove(Guid id, Guid by, string reason);
    }
}
