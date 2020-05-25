using CSharpFunctionalExtensions;
using Survey.Identity.Domain;
using Survey.Identity.Domain.Features;
using Survey.Identity.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Services.Features
{
    public class FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IMicroServiceRepository _serviceRepository;

        public FeatureService(IFeatureRepository featureRepository, IMicroServiceRepository serviceRepository)
        {
            _featureRepository = featureRepository;
            _serviceRepository = serviceRepository;
        }
        public async Task<Result> Create(string label, string description, string controller, string actionName,
                                         string action, Guid createdby, Guid microServiceId)
        {
            Result<FeatureInfo> featureInfoResult = FeatureInfo.Create(label, description, controller, actionName, action);
            if (featureInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Feature_feature_info_not_valid"));

            Result<CreateInfo> creatInfoResult = CreateInfo.Create(createdby);
            if (creatInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Feature_Create_Info_not_valid"));

            var service = _serviceRepository.FindByKey(microServiceId);
            if (service == null)
                return await Task<Result>.FromResult(Result.Failure($"MicroService_not_valid"));

            var feature = new Feature(featureInfoResult.Value, creatInfoResult.Value, service);
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

            if (feature.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));

            Result<DisableInfo> disableInfoResult = DisableInfo.Create(by);
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

            if (feature.DeleteInfo.Deleted || feature.DisableInfo.Disabled)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));


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

        public async Task<Result> Remove(Guid id, Guid by, string reason)
        {
            var feature = _featureRepository.FindByKey(id);
            if (feature == null)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));

            if (feature.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));


            Result<DeleteInfo> deleteInfoResult = DeleteInfo.Create(by, reason);
            if (deleteInfoResult.IsFailure)
                return await Task<Result>.FromResult(Result.Failure($"Could not remove feature"));

            feature.Remove(deleteInfoResult.Value);
            if (!_featureRepository.Save())
            {
                return await Task<Result>.FromResult(Result.Failure("Feature could not be deactivated"));
            }
            return await Task<Result>.FromResult(Result.Ok());
        }

        public bool DoesUseHaveAccesTo(Guid userId, string actionName)
        {
            return _featureRepository.DoesUserHaveAccessTo(userId, actionName);
        }
        public async Task<Result> Activate(Guid id)
        {
            var feature = _featureRepository.FindByKey(id);
            if (feature == null)
                return await Task<Result>.FromResult(Result.Failure($"feature_does_not_exist"));

            if (feature.DeleteInfo.Deleted)
                return await Task<Result>.FromResult(Result.Failure($"Feature_not_found"));


            if (!feature.DisableInfo.Disabled)
                return await Task<Result>.FromResult(Result.Failure($"feature_already_active"));

            feature.Activate();

            if (!_featureRepository.Save())
                return await Task<Result>.FromResult(Result.Failure("Could_not_activate_feature"));
            return await Task<Result>.FromResult(Result.Ok());
        }

    }
}
