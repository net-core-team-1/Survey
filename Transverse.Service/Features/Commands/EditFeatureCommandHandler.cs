using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Features.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class EditFeatureCommandHandler : ICommandHandler<EditFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public EditFeatureCommandHandler(
                                         IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;

        }
        public Task<Result> Handle(EditFeatureCommand command)
        {
            var feature = _featureRepository.FindByKey(command.Id);

            Result<FeatureInfo> featureInfoResult = FeatureInfo.Create(command.Label, command.Description,
                                                               command.Description, command.ControllerActionName,
                                                               command.Action);
            if (featureInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));

            feature.UpdateInfo(featureInfoResult.Value);

            if (!_featureRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Feature could not be updated"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
