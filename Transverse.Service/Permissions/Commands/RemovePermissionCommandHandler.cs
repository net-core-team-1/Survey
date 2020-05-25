using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions.Commands;
using System.Threading.Tasks;

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
        public Task<Result> Handle(RemovePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);

            Result<DeleteInfo> deletionObj = DeleteInfo.Create(command.By, command.Reason);
            if (deletionObj.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Could not disable user"));

            permission.Remove(deletionObj.Value);
            _permissionRepository.Save();
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
