using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Data.Repositories.Services;

namespace Identity.Api.Services.Features.CommandHandlers
{
    public class EditFeatureCommandHandler : ICommandHandler<EditFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IAppServiceRepository _appServiceRepository;
        public EditFeatureCommandHandler(IFeatureRepository featureRepository,
            IAppServiceRepository appServiceRepository)
        {
            _featureRepository = featureRepository;
            _appServiceRepository = appServiceRepository;
        }

        public Task<Result> Handle(EditFeatureCommand command)
        {
            var count = _featureRepository
                           .FindBy(x => x.FeatureInfo.Controller == command.ControllerName
                                   && x.FeatureInfo.ControllerActionName == command.ControllerActionName
                                   && x.ServiceId == command.AppServiceId
                                   && x.FeatureInfo.Label == command.Label
                                   && x.Id != command.FeatureId).Count();

            if (count != 0)
                throw new IdentityException("Duplicate_feature", "Feature with the same informations already exists in database, " +
                    "features infos must be unique per service");

            var feature = _featureRepository.FindByKey(command.FeatureId);
            if (feature == null)
                throw new IdentityException("FEATURE_NOT_FOUND", "Feature not found in database");

            var createFeatureResult = FeatureInfo.Create(command.Label, command.Description, command.ControllerName,
               command.ControllerActionName, command.Action).Validate();

            feature.UpdateInfo(createFeatureResult.Value);

            if (command.AppServiceId != feature.ServiceId)
            {
                var service = _appServiceRepository.FindByKey(command.AppServiceId);
                if (service == null)
                    throw new IdentityException("Service_not_found", "Service not found in database with the given Id");
                feature.ChangeService(service);
            }

            _featureRepository.Update(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while updating feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
