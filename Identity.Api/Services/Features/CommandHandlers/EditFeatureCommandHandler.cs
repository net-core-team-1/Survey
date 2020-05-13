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

namespace Identity.Api.Services.Features.CommandHandlers
{
    public class EditFeatureCommandHandler : ICommandHandler<EditFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public EditFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public Task<Result> Handle(EditFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.FeatureId);
            if (feature == null)
                throw new IdentityException("FEATURE_NOT_FOUND", "Feature not found in database");

            var createFeatureResult = FeatureInfo.Create(command.Label, command.Description, command.ControllerName,
               command.ControllerActionName, command.Action).Validate();

            var appService = new AppService(command.AppServiceId);

            feature.UpdateInfo(createFeatureResult.Value);
            feature.ChangeService(appService);

            _featureRepository.Update(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while updating feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
