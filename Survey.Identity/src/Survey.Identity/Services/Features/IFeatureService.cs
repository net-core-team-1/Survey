using CSharpFunctionalExtensions;
using System;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Features
{
    public interface IFeatureService
    {
        Task<Result> Create(string label, string description, string controller, string actionName, 
                            string action, Guid? createdby,Guid? microServiceId);
        Task<Result> Deactivate(Guid id, Guid by);

        Task<Result> EditInfo(Guid id, string label, string description);

        Task<Result> Remove(Guid id, Guid by, string reason);
        bool DoesUseHaveAccesTo(Guid userId, string actionName);

        Task<Result> Activate(Guid id);
    }
}
