using Common.Types.Types.ServiceBus;
using CSharpFunctionalExtensions;
using Survey.Common.Auth;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using System.Threading.Tasks;
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

        public Task<Result> Handle(RegisterUserCommand command)
        {
            Result<FullName> fullNameResult = FullName.Create(command.FirstName, command.LastName);
            if (fullNameResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"FirstName/LastName invalid "));

            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Email invalid "));

            Result<Password> passwordResult = Password.Create(command.Password, _encrypter);
            if (passwordResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Password invalid "));


            var user = new User(fullNameResult.Value, emailResult.Value, passwordResult.Value, command.Permissions);

            _userRepository.Insert(user);
            if (!_userRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("User could not be saved"));
            }

            _bus.PublishAsync(new UserRegistered(user.Id,command.FirstName, command.LastName, 
                                                 command.Email,user.CreateInfo.CreatedOn));

            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
