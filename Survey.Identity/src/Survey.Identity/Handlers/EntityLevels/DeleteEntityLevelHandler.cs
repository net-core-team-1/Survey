using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Domain.Entities.Levels.Commands;
using Survey.Identity.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Entities
{
    public class DeleteEntityLevelHandler : ICommandHandler<DeleteEntityLevelCommand>
    {
        private readonly IEntityLevelService _levelService;

        public DeleteEntityLevelHandler(IEntityLevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<Result> Handle(DeleteEntityLevelCommand command)
        {
            return await _levelService.Delete(command.Id, command.By, command.Reason);
        }
    }
}
