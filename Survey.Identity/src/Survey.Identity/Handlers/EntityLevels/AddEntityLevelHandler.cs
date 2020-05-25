using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Domain.Entities.Levels.Commands;
using Survey.Identity.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.EntityLevels
{
    public class AddEntityLevelHandler : ICommandHandler<AddEntityLevelCommand>
    {
        private readonly IEntityLevelService _levelService;

        public AddEntityLevelHandler(IEntityLevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<Result> Handle(AddEntityLevelCommand command)
        {
            return await _levelService.Create(command.Id, command.Name, command.Description, command.ParentId,
                                               command.CreatedBy);
        }
    }
}
