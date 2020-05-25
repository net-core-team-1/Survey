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
    public class CreateFeatureHandler : ICommandHandler<CreateFeatureCommand>
    {
        private readonly IFeatureService _featureService;

        public CreateFeatureHandler(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<Result> Handle(CreateFeatureCommand command)
        {
            return await _featureService.Create(command.Label, command.Description, command.Controller,
                                          command.ControllerActionName, command.Action, command.CreatedBy,
                                          command.MicroServiceId);
        }
    }
}
