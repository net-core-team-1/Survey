using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Survey.Common.Auth;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Transverse.Domain.Users.Events;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IBusPublisher _bus;

        public RegisterUserCommandHandler(IEncrypter encrypter,
                                          IUserRepository userRepository,
                                          IBusPublisher bus)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _bus = bus;
        }

        public Result Handle(RegisterUserCommand command)
        {
            Result<FullName> fullNameResult = FullName.Create(command.FirstName, command.LastName);
            if (fullNameResult.IsFailure)
                return Result.Failure($"FirstName/LastName invalid ");

            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return Result.Failure($"Email invalid ");

            Result<Password> passwordResult = Password.Create(command.Password, _encrypter);
            if (passwordResult.IsFailure)
                return Result.Failure($"Password invalid ");


            var user = new User(fullNameResult.Value, emailResult.Value, passwordResult.Value, command.Permissions);
            
            _userRepository.Insert(user);
            if (!_userRepository.Save())
            {
                return Result.Failure("User could not be saved");
            }

            _bus.PublishAsync(new UserRegistered(command.FirstName, command.LastName, command.Email));

            return Result.Ok();
        }
    }
}
