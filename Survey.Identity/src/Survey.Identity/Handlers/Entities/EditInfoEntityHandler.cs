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
    public class EditInfoEntityHandler : ICommandHandler<EditInfoEntityCommand>
    {
        private readonly IEntityService _entityService;

        public EditInfoEntityHandler(IEntityService entityService)
        {
            _entityService = entityService;
        }
        public async Task<Result> Handle(EditInfoEntityCommand command)
        {
            return await _entityService.EditInfo(command.Id, command.Name, command.Description,
                                               command.Code/*, command.ParentId, command.LevelId*/);
        }
    }
}
