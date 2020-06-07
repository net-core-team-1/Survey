using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Entities.Commands;
using Survey.Identity.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Entities
{
    public class CreateEntityHandler : ICommandHandler<CreateEntityCommand>
    {
        private readonly IEntityService _entityService;

        public CreateEntityHandler(IEntityService entityService)
        {
            _entityService = entityService;
        }
        public async Task<Result> Handle(CreateEntityCommand command)
        {
            return await _entityService.Create( command.Name, command.Description,
                                               command.Code,/* command.ParentId, command.LevelId,*/
                                               command.CreatedBy);
        }
    }
}
