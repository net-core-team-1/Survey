using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Features;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Identity.Domain.Features;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Features.CommandHandlers
{
    public class RegisterFeatureCommandHandler : ICommandHandler<RegisterFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;
        private readonly IAppServiceRepository _appServiceRepository;

        public RegisterFeatureCommandHandler(IFeatureRepository featureRepository,
             IAppServiceRepository appServiceRepository)
        {
            _featureRepository = featureRepository;
            _appServiceRepository = appServiceRepository;
        }

        public Task<Result> Handle(RegisterFeatureCommand command)
        {
            var count = _featureRepository
                            .FindBy(x => x.FeatureInfo.Controller == command.ControllerName
                                    && x.FeatureInfo.ControllerActionName == command.ControllerActionName
                                    && x.ServiceId == command.AppServiceId
                                    && x.FeatureInfo.Label == command.Label).Count();
            if (count != 0)
                throw new IdentityException("Duplicate_feature", "Feature with the same informations already exists in database, " +
                    "features infos must be unique per service");

            var service = _appServiceRepository.FindByKey(command.AppServiceId);
            if (service == null)
                throw new IdentityException("Service_not_found", "Service not found in database with the given Id");

            var createFeatureResult = FeatureInfo.Create(command.Label, command.Description, command.ControllerName,
                command.ControllerActionName, command.Action).Validate();
            var createInfoResult = CreateInfo.Create(command.CreatedBy);
            var feature = new Feature(createFeatureResult.Value, createInfoResult.Value, service);
            _featureRepository.Insert(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while creating feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
