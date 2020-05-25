using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Domain.Features.Commands;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class UpdateFeaturesHandler : ICommandHandler<UpdateRoleFeaturesCommand>
    {
        private readonly IRoleService _roleService;

        public UpdateFeaturesHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(UpdateRoleFeaturesCommand command)
        {
            return await _roleService.UpdateFeatures(command.Id, command.Features);
        }
    }
}
