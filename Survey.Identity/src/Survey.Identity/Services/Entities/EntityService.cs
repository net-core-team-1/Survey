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
        //private IEntityLevelRepository _entityLevelRepository;

        public EntityService(IEntityRepository entityRepository/*, IEntityLevelRepository entityLevelRepository*/)
        {
            _entityRepository = entityRepository;
            //_entityLevelRepository = entityLevelRepository;
        }
        public async Task<Result> Create(string name, string description, string code,
                                   /*Guid? parentId, Guid levelId,*/ Guid createdBy)
        {
            var entity = _entityRepository.FindByCode(code);
            if (entity != null)
                return await Task<Result>.FromResult(Result.Failure($"func_code_already_in_use"));

            Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
            if (nameDescriptionResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));

            Result<FunctionalCode> functionalCodeResult = FunctionalCode.Create(code);
            if (functionalCodeResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(functionalCodeResult.Error));

            Result<CreateInfo> createInfoResult = CreateInfo.Create(createdBy);
            if (createInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure(createInfoResult.Error));

            //var levelEntity = _entityLevelRepository.FindByKey(levelId);
            //if (levelEntity == null)
            //    return await Task<Result>.FromResult(Result.Failure($"entity_mast_have_a_level_in_heirarchy"));


            //var parent = _entityRepository.FindByKey(parentId);
            //if (parent == null && levelEntity.Parent != null)
            //    return await Task<Result>.FromResult(Result.Failure($"entity_must_have_a_parent"));


            var newEntity = new Entity(nameDescriptionResult.Value, functionalCodeResult.Value,
                                        createInfoResult.Value
                                    /*levelEntity,  parent*/);

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

        public Task<Result> EditInfo(Guid id, string name, string description, string code/*, Guid? parentId, Guid levelId*/)
        {
            var entity = _entityRepository.FindByKey(id);
            if (entity == null)
                return Task<Result>.FromResult(Result.Failure($"no_entity_found"));

            Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
            if (nameDescriptionResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));

            Result<FunctionalCode> functionalCodeResult = FunctionalCode.Create(code);
            if (functionalCodeResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure(functionalCodeResult.Error));

            //var levelEntity = _entityLevelRepository.FindByKey(levelId);
            //if (levelEntity == null)
            //    return Task<Result>.FromResult(Result.Failure($"entity_mast_have_a_level_in_heirarchy"));


            //var parent = _entityRepository.FindByKey(parentId);

            //if (parent == null && levelEntity.Parent != null)
            //    return Task<Result>.FromResult(Result.Failure($"entity_must_have_a_parent"));

            entity.EditInfo(nameDescriptionResult.Value, functionalCodeResult.Value/*, parent, levelEntity*/);


            if (!_entityRepository.Save())
                return Task<Result>.FromResult(Result.Failure("could_not_save_the_entity"));

            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
