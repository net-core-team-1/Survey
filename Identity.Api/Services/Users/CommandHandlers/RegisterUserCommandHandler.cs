using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Identity.Api.Exceptions;
using Identity.Api.Identity.Domain;
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
        private readonly IResultValidator _resultValidation;
        private readonly IResultIdentityValidation _identityResultValidator;

        public RegisterUserCommandHandler(IUserService userService, IBusPublisher bus,
              IResultValidator resultValidation, IResultIdentityValidation identityResultValidator)
        {
            _userService = userService;
            _bus = bus;
            _resultValidation = resultValidation;
            _identityResultValidator = identityResultValidator;
        }

        public async Task<Result> Handle(RegisterUserCommand command)
        {
            var fullNameResult = FullName.Create(command.FirstName, command.LastName);
            var Civility = new Civility(command.CivilityId);
            var passwordResult = UserPassword.Create(command.Password);
            var rolesResult = AppUserRoleCollection.Create(command.Permissions);
            var userNameResult = UserName.Create(command.UserName);
            var emailResult = UserEmail.Create(command.Email);

            _resultValidation.Validate<FullName>(fullNameResult);
            _resultValidation.Validate<AppUserRoleCollection>(rolesResult);
            _resultValidation.Validate<UserPassword>(passwordResult);
            _resultValidation.Validate<UserEmail>(emailResult);
            _resultValidation.Validate<UserName>(userNameResult);

            var user = new AppUser(userNameResult.Value, fullNameResult.Value,
                emailResult.Value, rolesResult.Value, Civility);
            var result = await _userService.RegisterNewAsync(user, passwordResult.Value);
            _identityResultValidator.Validate(result);

            _bus.PublishAsync<UserRegistered>(new UserRegistered(user.Id, user.FullName.FirstName, user.FullName.LastName, user.Email));

            return await Task.FromResult(Result.Ok());
        }
    }
}
