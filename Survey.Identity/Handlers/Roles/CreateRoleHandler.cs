using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class CreateRoleHandler : ICommandHandler<CreateRoleCommand>
    {
        private readonly IRoleService _roleService;

        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(CreateRoleCommand command)
        {
            return await _roleService.Create(command.Name, command.CreatedBy, command.Features);
        }
    }
}
