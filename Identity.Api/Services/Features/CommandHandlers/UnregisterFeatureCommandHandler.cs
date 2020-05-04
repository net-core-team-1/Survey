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
    public class UnregisterFeatureCommandHandler : ICommandHandler<UnRegisterFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public UnregisterFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public Task<Result> Handle(UnRegisterFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.FeatureId);
            if (feature == null)
                throw new IdentityException("FEATURE_NOT_FOUND", "Feature not found in database");

            var deleteInfoResult = DeleteInfo.Create(command.FeatureId, command.Reason, DateTime.Now.ToUniversalTime())
                                             .Validate();

            feature.Remove(deleteInfoResult.Value);

            _featureRepository.Update(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while updating feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
