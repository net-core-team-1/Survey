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
    public class EditFeatureHandler : ICommandHandler<EditFeatureCommand>
    {
        private readonly IFeatureService _featureService;

        public EditFeatureHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<Result> Handle(EditFeatureCommand command)
        {
            return await _featureService.EditInfo(command.Id,command.Label, command.Description);
        }
    }
}
