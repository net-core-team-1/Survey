using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class RemoveRoleHandler : ICommandHandler<RemoveRoleCommand>
    {
        private readonly IRoleService _roleService;

        public RemoveRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(RemoveRoleCommand command)
        {
            return await _roleService.Remove(command.Id, command.By, command.Reason);
        }
    }
}
