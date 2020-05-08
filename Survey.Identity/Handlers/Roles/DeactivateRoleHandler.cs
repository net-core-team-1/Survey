using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class DeactivateRoleHandler : ICommandHandler<DeactivateRoleCommand>
    {
        private readonly IRoleService _roleService;

        public DeactivateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(DeactivateRoleCommand command)
        {
            return await _roleService.Deactivate(command.Id, command.DisabledBy);
        }
    }
}
