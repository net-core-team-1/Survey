using CSharpFunctionalExtensions;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Entities
{
    public class EntityService : IEntityService
    {
        private readonly IEntityRepository _entityRepository;

        public EntityService(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }
        public async Task<Result> Create(string name, string description, Guid? createdBy)
        {


            Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
            if (nameDescriptionResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));

            Result<CreateInfo> createInfoResult = CreateInfo.Create(createdBy);
            if (createInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(createInfoResult.Error));

            var newEntity = new Entity(nameDescriptionResult.Value, createInfoResult.Value);

            _entityRepository.Insert(newEntity);

            if (!_entityRepository.Save())
                return await Task<Result>.FromResult(Result.Failure("could_not_save_the_new_entity"));

            return await Task<Result>.FromResult(Result.Ok());

        }

        public async Task<Result> Delete(Guid id, Guid by, string reason)
        {
            var entity = _entityRepository.FindByKey(id);
            if (entity == null)
                return await Task<Result>.FromResult(Result.Failure($"no_entity_found"));

            if (entity.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"entity_already_deleted"));

            Result<DeleteInfo> deleteResult = DeleteInfo.Create(by, reason);
            if (deleteResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"delete_info_not_valid"));

            entity.Delete(deleteResult.Value);
            if (!_entityRepository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("could_not_delete_entity"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }

        public Task<Result> EditInfo(Guid id, string name, string description)
        {
            var entity = _entityRepository.FindByKey(id);
            if (entity == null)
                return Task<Result>.FromResult(Result.Failure($"no_entity_found"));

            Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
            if (nameDescriptionResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));



            entity.EditInfo(nameDescriptionResult.Value);


            if (!_entityRepository.Save())
                return Task<Result>.FromResult(Result.Failure("could_not_save_the_entity"));

            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
