using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Services.Features;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Features
{
    public class ActivateFeatureHandler : ICommandHandler<ActivateFeatureCommand>
    {
        private readonly IFeatureService _featureService;

        public ActivateFeatureHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<Result> Handle(ActivateFeatureCommand command)
        {
            return await _featureService.Activate(command.Id);
        }
    }
}
