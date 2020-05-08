using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Data.Repositories.Features;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Features.Commands;
using Identity.Api.Utils.ResultValidator;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Features.CommandHandlers
{
    public class DisableFeatureCommandHandler : ICommandHandler<DisableFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public DisableFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public Task<Result> Handle(DisableFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.FeatureId);
            if (feature == null)
                throw new IdentityException("FEATURE_NOT_FOUND", "Feature not found in database");

            var disableInfoResult = DisabeleInfo.Create(true, command.DisabledBy)
                                             .Validate();

            feature.Deactivate(disableInfoResult.Value);

            _featureRepository.Update(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while disabling feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
