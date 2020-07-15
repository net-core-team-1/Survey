using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Services.Commands;
using Survey.Identity.Services.MicroServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.MicroServices
{
    public class CreateMicroServiceHandler : ICommandHandler<CreateMicroServiceCommand>
    {
        private readonly IMicroServiceService _microServiceService;

        public CreateMicroServiceHandler(IMicroServiceService microServiceService)
        {
            _microServiceService = microServiceService;
        }
        public Task<Result> Handle(CreateMicroServiceCommand command)
        {
            return _microServiceService.Insert(command.Name, command.Description, command.CreatedBy);
        }
    }
}
