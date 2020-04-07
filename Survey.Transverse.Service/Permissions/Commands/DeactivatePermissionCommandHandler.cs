using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Features;
using Survey.Transverse.Domain.Permissions.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Result Handle(DeactivatePermissionCommand command)
        {
            var permission = _permissionRepository.FindByKey(command.Id);

            Result<DisabeleInfo> disableInfoResult = DisabeleInfo.Create(command.DisabledBy);
            if (disableInfoResult.IsFailure)
                return Result.Failure($"Error");

            permission.Deactivate(disableInfoResult.Value);
            if (!_permissionRepository.Save())
            {
                return Result.Failure("Permission could not be deactivated");
            }
            return Result.Ok();
        }
    }
}
