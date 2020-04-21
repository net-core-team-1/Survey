using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class DeactivatePermissionCommandHandler : ICommandHandler<DeactivatePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public DeactivatePermissionCommandHandler(
                                                  IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }
        public Task<Result> Handle(DeactivatePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(command.DisabledBy);
            if (disableInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));

            permission.Deactivate(disableInfoResult.Value);
            if (!_permissionRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Permission could not be deactivated"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
