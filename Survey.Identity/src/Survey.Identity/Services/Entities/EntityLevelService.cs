using CSharpFunctionalExtensions;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Entities
{
    //public class EntityLevelService : IEntityLevelService
    //{
    //    private readonly IEntityLevelRepository _repository;

    //    public EntityLevelService(IEntityLevelRepository repository)
    //    {
    //        _repository = repository;
    //    }
    //    public Task<Result> Create(Guid id, string name, string description,
    //                               Guid? parentId, Guid createdBy)
    //    {
    //        var nameAvailibale = _repository.IsNameAvailibale(name);
    //        if (!nameAvailibale)
    //            return Task<Result>.FromResult(Result.Failure($"name_already_in_use"));

    //        Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
    //        if (nameDescriptionResult.IsFailure)
    //            return Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));


    //        Result<CreateInfo> createInfoResult = CreateInfo.Create(createdBy);
    //        if (createInfoResult.IsFailure)
    //            return Task<Result>.FromResult(Result.Failure(createInfoResult.Error));

    //        var parent = _repository.FindByKey(parentId);
    //        if (parent == null)
    //            return Task<Result>.FromResult(Result.Failure($"entity_level_must_have_a_parent"));

    //        var newEntity = new EntityLevel(nameDescriptionResult.Value, createInfoResult.Value, parent);

    //        _repository.Insert(newEntity);

    //        if (!_repository.Save())
    //            return Task<Result>.FromResult(Result.Failure("could_not_save_the_new_entity"));

    //        return Task<Result>.FromResult(Result.Ok());

    //    }

    //    public async Task<Result> Delete(Guid id, Guid by, string reason)
    //    {
    //        var entity = _repository.FindByKey(id);
    //        if (entity == null)
    //            return await Task<Result>.FromResult(Result.Failure($"no_entity_found"));

    //        if (entity.DeleteInfo.Deleted)
    //            return await Task<Result>.FromResult(Result.Failure($"entity_already_deleted"));

    //        Result<DeleteInfo> deleteResult = DeleteInfo.Create(by, reason);
    //        if (deleteResult.IsFailure)
    //            return await Task<Result>.FromResult(Result.Failure($"delete_info_not_valid"));

    //        entity.Delete(deleteResult.Value);
    //        if (!_repository.Save())
    //        {
    //            return await Task<Result>.FromResult(Result.Failure("counld_not_delete_entity"));
    //        }
    //        return await Task<Result>.FromResult(Result.Ok());
    //    }

    //    public Task<Result> EditInfo(Guid id, string name, string description, Guid? parentId)
    //    {

    //        Result<NameDesc> nameDescriptionResult = NameDesc.Create(name, description);
    //        if (nameDescriptionResult.IsFailure)
    //            return Task<Result>.FromResult(Result.Failure(nameDescriptionResult.Error));

    //        var entity = _repository.FindByKey(id);
    //        if (entity == null)
    //            return Task<Result>.FromResult(Result.Failure($"no_entity_found"));


    //        var nameAvailibale = _repository.IsNameAvailibale(name);
    //        if (!nameAvailibale && entity.NameDesciption.Name != name)
    //            return Task<Result>.FromResult(Result.Failure($"name_already_in_use"));

    //        var parent = _repository.FindByKey(parentId);
    //        if (parent == null)
    //            return Task<Result>.FromResult(Result.Failure($"entity_level_must_have_a_parent"));

    //        entity.EditInfo(nameDescriptionResult.Value, parent);


    //        if (!_repository.Save())
    //            return Task<Result>.FromResult(Result.Failure("could_not_save_the_new_entity"));

    //        return Task<Result>.FromResult(Result.Ok());
    //    }
    //}
}
