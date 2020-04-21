using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;
using System.Threading.Tasks;

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
        public Task<Result> Handle(DeactivateFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            if (feature == null)
                return Task<Result>.FromResult(Result.Failure($"No feature found for Id= {command.Id}"));

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(command.DisabledBy);
            if (disableInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));

            feature.Deactivate(disableInfoResult.Value);
            if (!_featureRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Feature could not be deactivated"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
