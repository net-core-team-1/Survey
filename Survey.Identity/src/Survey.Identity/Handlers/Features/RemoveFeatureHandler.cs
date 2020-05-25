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
    public class RemoveFeatureHandler : ICommandHandler<RemoveFeatureCommand>
    {
        private readonly IFeatureService _featureService;

        public RemoveFeatureHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<Result> Handle(RemoveFeatureCommand command)
        {
            return await _featureService.Remove(command.Id,command.DeletedBy, command.Reason);
        }
    }
}
