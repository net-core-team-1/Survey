using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Services.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Features
{
    public class DeactivateFeatureHandler : ICommandHandler<DeactivateFeatureCommand>
    {
        private readonly IFeatureService _featureService;

        public DeactivateFeatureHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<Result> Handle(DeactivateFeatureCommand command)
        {
            return await _featureService.Deactivate(command.Id, command.DisabledBy);
        }
    }
}
