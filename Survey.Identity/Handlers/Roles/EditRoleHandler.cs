using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Identity.Services.Roles;
using Survey.Indentity.Domain.Roles.Commands;
using System.Threading.Tasks;

namespace Survey.Identity.Handlers.Roles
{
    public class EditRoleHandler : ICommandHandler<EditRoleCommand>
    {
        private readonly IRoleService _roleService;

        public EditRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<Result> Handle(EditRoleCommand command)
        {
            return await _roleService.EditName(command.Id, command.Name);
        }
    }
}
