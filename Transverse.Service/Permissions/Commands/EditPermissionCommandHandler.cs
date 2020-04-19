using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Permissions.Commands;
using System.Linq;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class EditPermissionCommandHandler : ICommandHandler<EditPermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public EditPermissionCommandHandler(
                                              IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

        }
        public Task<Result> Handle(EditPermissionCommand command)
        {
            var permission = _permissionRepository.FindByInclude(a => a.Id == command.Id, a => a.PermissionFeatures).FirstOrDefault();
            if (permission == null)
                return Task<Result>.FromResult(Result.Failure($"Could not fetch the permission"));

            Result<PermissionInfo> permissionInfoResult = PermissionInfo.Create(command.Label, command.Description);
            if (permissionInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));


            permission.Update(permissionInfoResult.Value, command?.Features, command.DeleteExistingFeatures);

           // _permissionRepository.UpdateFeatures(permission, command.DeleteExistingFeatures);
            if (!_permissionRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Permission could not be saved"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
