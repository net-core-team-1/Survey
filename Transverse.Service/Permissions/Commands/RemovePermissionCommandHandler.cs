using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions.Commands;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class RemovePermissionCommandHandler : ICommandHandler<RemovePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public RemovePermissionCommandHandler(
                                              IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public Result Handle(RemovePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);

            Result<DeleteInfo> deletionObj = DeleteInfo.Create(command.By, command.Reason);
            if (deletionObj.IsFailure)
                return Result.Failure($"Could not disable user");

            permission.Remove(deletionObj.Value);
            _permissionRepository.Save();
            return Result.Ok();
        }
    }
}
