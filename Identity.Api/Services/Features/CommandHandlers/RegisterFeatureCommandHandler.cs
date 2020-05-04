using CSharpFunctionalExtensions;
using Identity.Api.Identity.Data.Repositories.Features;
using Identity.Api.Identity.Domain;
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

        public RegisterFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public Task<Result> Handle(RegisterFeatureCommand command)
        {
            var createFeatureResult = FeatureInfo.Create(command.Label, command.Description, command.ControllerName,
                command.ControllerActionName, command.Action).Validate();
            var createInfoResult = CreateInfo.Create(command.CreatedBy);

            var feature = new Feature(createFeatureResult.Value, createInfoResult.Value);
            _featureRepository.Insert(feature);
            if (_featureRepository.Save())
            {
                return Task.FromResult(Result.Failure("Error while creating feature"));
            }
            return Task.FromResult(Result.Ok());
        }
    }
}
