using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Entities.Levels.Commands;
using Survey.Identity.Services.Entities;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Entities
{
    public class EditInfoEntityLevelHandler : ICommandHandler<EditInfoEntityLevelCommand>
    {
        private readonly IEntityLevelService _levelService;

        public EditInfoEntityLevelHandler(IEntityLevelService levelService)
        {
            _levelService = levelService;
        }
        public async Task<Result> Handle(EditInfoEntityLevelCommand command)
        {
            return await _levelService.EditInfo(command.Id, command.Name, command.Description, command.ParentId);
        }
    }
}
