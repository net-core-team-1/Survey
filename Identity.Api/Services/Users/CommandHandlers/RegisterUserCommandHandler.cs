using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
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

        public RegisterUserCommandHandler(IUserService userService, IBusPublisher bus)
        {
            _userService = userService;
            _bus = bus;
        }

        public async Task<Result> Handle(RegisterUserCommand command)
        {
            throw new NotImplementedException();
            //var fullNameResult = FullName.Create(command.FirstName, command.LastName).Validate();

            //var civility = new Civility(command.CivilityId);
            //var passwordResult = UserPassword.Create(command.Password).Validate();
            //var rolesResult = AppUserRoleCollection.Create().Validate();
            //var userNameResult = UserName.Create(command.UserName).Validate();
            //var emailResult = UserEmail.Create(command.Email).Validate();

            //var user = new AppUser(userNameResult.Value, fullNameResult.Value,
            //    emailResult.Value, rolesResult.Value, civility);
            //var result = await _userService.RegisterNewAsync(user, passwordResult.Value);
            //result.Validate();

            //_bus.PublishAsync<UserRegistered>(new UserRegistered(user.Id, user.FullName.FirstName, user.FullName.LastName, user.Email));

            //return await Task.FromResult(Result.Ok());
        }
    }
}
