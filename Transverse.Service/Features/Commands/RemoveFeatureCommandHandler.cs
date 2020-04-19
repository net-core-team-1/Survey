using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Features.Commands
{
    public sealed class RemoveFeatureCommandHandler : ICommandHandler<RemoveFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public RemoveFeatureCommandHandler(
                                      IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }
        public Task<Result> Handle(RemoveFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);
            if (feature == null)
                return Task<Result>.FromResult(Result.Failure($"No feature found for Id= {command.Id}"));

            Result<DeleteInfo> deletionObj = DeleteInfo.Create(command.DeletedBy, command.Reason);
            if (deletionObj.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Could not disable user"));


            feature.Remove(deletionObj.Value);
            if (!_featureRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Feature could not be deactivated"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
