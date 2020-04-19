using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;

namespace Survey.Transverse.Service.Features.Commands
{
    public sealed class DeactivateFeatureCommandHandler : ICommandHandler<DeactivateFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public DeactivateFeatureCommandHandler(
                                      IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public Result Handle(DeactivateFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            if (feature == null)
                return Result.Failure($"No feature found for Id= {command.Id}");

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(command.DisabledBy);
            if (disableInfoResult.IsFailure)
                return Result.Failure($"Error");

            feature.Deactivate(disableInfoResult.Value);
            if (!_featureRepository.Save())
            {
                return Result.Failure("Feature could not be deactivated");
            }
            return Result.Ok();
        }
    }
}
