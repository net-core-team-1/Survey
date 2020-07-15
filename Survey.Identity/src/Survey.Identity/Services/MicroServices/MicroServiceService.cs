using CSharpFunctionalExtensions;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.MicroServices
{
    public class MicroServiceService : IMicroServiceService
    {
        private readonly IMicroServiceRepository _repository;

        public MicroServiceService(IMicroServiceRepository repository)
        {
            _repository = repository;
        }
        public MicroService FindByKey(Guid id)
        {
            return _repository.FindByKey(id);
        }

        public async Task<Result> Insert(string name, string description, Guid? createdBy)
        {
            Result<CreateInfo> createInfoResult = CreateInfo.Create(createdBy);
            if (createInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Service_Create_info_not_valid"));

            var service = new MicroService(name, description, createInfoResult.Value);

            _repository.Insert(service);
            if (!_repository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("Service_Create_info_could_not_be_saved"));
            }
            return Result.Success();
        }
    }
}
