using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions;
using Survey.Transverse.Domain.Permissions.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Permissions.Commands
{
    public sealed class CreatePermissionCommandHandler : ICommandHandler<CreatePermissionCommand>
    {
        private readonly IPermissionRepository _permissionRepository;

        public CreatePermissionCommandHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;

        }
        public Task<Result> Handle(CreatePermissionCommand command)
        {
            Result<CreateInfo> createInfoResult = CreateInfo.Create(command.CreatedBy);
            if (createInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));

            Result<PermissionInfo> permissionInfoResult = PermissionInfo.Create(command.Label, command.Description);
            if (permissionInfoResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Error"));

            var permission = new Permission(permissionInfoResult.Value, createInfoResult.Value, command?.Features);
            _permissionRepository.Insert(permission);
            if (!_permissionRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Permission could not be saved"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
