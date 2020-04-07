using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Handle(RegisterUserCommand command)
        {
            Result<FullName> fullNameResult = FullName.Create(command.FirstName, command.LastName);
            if (fullNameResult.IsFailure)
                return Result.Failure($"FirstName/LastName invalid ");

            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return Result.Failure($"Email invalid ");

            Result<Password> passwordResult = Password.Create(command.Password);
            if (passwordResult.IsFailure)
                return Result.Failure($"Password invalid ");


            var user = new User(fullNameResult.Value, emailResult.Value, passwordResult.Value, command.Permissions);
            
            _userRepository.Insert(user);
            if (!_userRepository.Save())
            {
                return Result.Failure("User could not be saved");
            }
            return Result.Ok();
        }
    }
}
