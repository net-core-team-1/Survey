using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Data.Repositories.Structures;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
using Identity.Api.Identity.Domain.AppUserRoles;
using Identity.Api.Identity.Domain.Civilities;
using Identity.Api.Identity.Domain.Roles;
using Identity.Api.Identity.Domain.Users;
using Identity.Api.Identity.Domain.Users.Commands;
using Identity.Api.Identity.Domain.Users.Events;
using Identity.Api.Utils.ResultValidator;
using Microsoft.EntityFrameworkCore.Update;
using Survey.Common.Types;
using Survey.Identity.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Services.Users.CommandHandlers
{
    public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserService _userService;
        private readonly IBusPublisher _bus;
        private readonly IStructureRepository _structureRepository;

        public RegisterUserCommandHandler(IUserService userService
            , IBusPublisher bus
            , IStructureRepository structureRepository)
        {
            _userService = userService;
            _bus = bus;
            _structureRepository = structureRepository;
        }

        public async Task<Result> Handle(RegisterUserCommand command)
        {
            var fullNameResult = FullName.Create(command.FirstName, command.LastName).Validate();
            var civility = new Civility(command.CivilityId);
            var passwordResult = UserPassword.Create(command.Password).Validate();
            var userNameResult = UserName.Create(command.UserName).Validate();
            var emailResult = UserEmail.Create(command.Email).Validate();
            var structure = _structureRepository.FindByKey(command.StructureId);
            if (structure == null)
                throw new IdentityException("Structure not found", "No structure found in database with the given key!");

            var user = new AppUser(userNameResult.Value, fullNameResult.Value,
                emailResult.Value, command.Permissions, civility, structure);

            var result = await _userService.RegisterNewAsync(user, passwordResult.Value);
            result.Validate();

            return await Task.FromResult(Result.Ok());
        }
    }
}
