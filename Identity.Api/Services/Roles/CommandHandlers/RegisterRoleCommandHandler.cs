using CSharpFunctionalExtensions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Roles.Commands;
using Identity.Api.Identity.Services.Roles;
using Identity.Api.Identity.Domain.AppServices;
using Identity.Api.Utils.ResultValidator;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Survey.Common.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Data.Repositories.Services;
using Identity.Api.Exceptions;

namespace Identity.Api.Services.Roles.CommandHandlers
{
    public class RegisterRoleCommandHandler : ICommandHandler<RegisterRoleCommand>
    {
        private readonly IRoleService _roleService;
        private readonly IStructureRepository _structureRepository;
        private readonly IAppServiceRepository _serviceRepository;

        public RegisterRoleCommandHandler(IRoleService roleService
            , IStructureRepository structureRepository
            , IAppServiceRepository serviceRepository)
        {
            _roleService = roleService;
            _structureRepository = structureRepository;
            _serviceRepository = serviceRepository;
        }

        public async Task<Result> Handle(RegisterRoleCommand command)
        {
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure_not_found", "the given structure id not found in database.");

            var appService = _serviceRepository.FindByKey(command.AppServiceId);
            if (appService == null)
                throw new IdentityException("App_service_not_found", "the given AppService id not found in database.");

            var createInfoResult = CreateInfo.Create(command.CreatedBy).Validate();
            var role = new AppRole(createInfoResult.Value, command.Name, command.Description,
                appService.Id, structure.Id);

            await _roleService.RegisterNewAsync(role);
            return await Task.FromResult(Result.Ok());
        }
    }
}
