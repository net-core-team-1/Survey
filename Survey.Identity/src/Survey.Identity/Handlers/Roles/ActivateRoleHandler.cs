using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class ActivateRoleHandler : ICommandHandler<ActivateRoleCommand>
    {
        private readonly IRoleService _roleService;

        public ActivateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(ActivateRoleCommand command)
        {
            return await _roleService.Activate(command.Id);
        }
    }
}
