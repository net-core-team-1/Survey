using CSharpFunctionalExtensions;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Features
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;

        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public async Task<Result> Create(string label, string description, string controller, string actionName, string action, Guid createdby)
        {
            Result<FeatureInfo> featureInfoResult = FeatureInfo.Create(label, description, controller, actionName, action);
            if (featureInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Feature_feature_info_not_valid"));

            Result<CreateInfo> creatInfoResult = CreateInfo.Create(createdby);
            if (creatInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Feature_Create_Info_not_valid"));

            var feature = new Feature(featureInfoResult.Value, creatInfoResult.Value);
            _featureRepository.Insert(feature);
            if (!_featureRepository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("Feature could not be saved"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> Deactivate(Guid id, Guid by)
        {
            var feature = _featureRepository.FindByKey(id);
            if (feature == null)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(by);
            if (disableInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Error"));

            feature.Deactivate(disableInfoResult.Value);
            if (!_featureRepository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("Feature could not be deactivated"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }

        public async Task<Result> EditInfo(Guid id, string label, string description)
        {
            var feature = _featureRepository.FindByKey(id);

            if (feature == null)
                return await Task<Result>.FromResult(Result.Failure($"Feature_does_not_exist"));

            Result<FeatureInfo> featureInfoResult = FeatureInfo.Create(label, description, feature.FeatureInfo.Controller,
                                                                       feature.FeatureInfo.ControllerActionName, feature.FeatureInfo.Action);
            if (featureInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Feature_update_info_invalid"));

            feature.UpdateInfo(featureInfoResult.Value);

            if (!_featureRepository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("Feature could not be updated"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }

        public Task<Result> Remove(Guid id, Guid by, string reason)
        {
            var feature = _featureRepository.FindByKey(id);
            if (feature == null)
                return Task<Result>.FromResult(Result.Failure($"Feature_not_found"));

            Result<DeleteInfo> deleteInfoResult = DeleteInfo.Create(by, reason);
            if (deleteInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Could not remove feature"));

            feature.Remove(deleteInfoResult.Value);
            if (!_featureRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Feature could not be deactivated"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }

        public bool DoesUseHaveAccesTo(Guid userId, string actionName)
        {
            return _featureRepository.DoesUserHaveAccessTo(userId, actionName);
        }
    }
}
