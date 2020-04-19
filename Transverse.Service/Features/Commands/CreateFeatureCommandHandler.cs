using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;

namespace Survey.Transverse.Service.Features.Commands
{
    public sealed class CreateFeatureCommandHandler : ICommandHandler<CreateFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public CreateFeatureCommandHandler(
                                      IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public Result Handle(CreateFeatureCommand command)
        {
            Result<CreateInfo> creationObj = CreateInfo.Create(command.CreatedBy);
            if (creationObj.IsFailure)
                return Result.Failure($"Error");

            Result<FeatureInfo> featureInfoResult = FeatureInfo.Create(command.Label, command.Description,
                                                                command.Description, command.ControllerActionName,
                                                                command.Action);
            if (featureInfoResult.IsFailure)
                return Result.Failure($"Error");

            var feature = new Feature(featureInfoResult.Value, creationObj.Value);
            _featureRepository.Insert(feature);
            if (!_featureRepository.Save())
            {
                return Result.Failure("Feature could not be saved");
            }
            return Result.Ok();
        }
    }
}
