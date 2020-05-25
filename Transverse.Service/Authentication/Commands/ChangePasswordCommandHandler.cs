using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using Survey.Transverse.Domain.Users;
using System.Threading.Tasks;
using Survey.Auth;

namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class ChangePasswordCommandHandler : ICommandHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public ChangePasswordCommandHandler(IEncrypter encrypter,
                                            IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public Task<Result> Handle(ChangePasswordCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Task<Result>.FromResult(Result.Failure($"No user found for Id={command.Id}"));

            if (!user.VerifyPassword(command.OldPassword, _encrypter))
                return Task<Result>.FromResult(Result.Failure("Incorrect password"));

            Result<Password> passwordResult = Password.Create(command.NewPassword, _encrypter);
            if (passwordResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Password invalid "));

            user.SetPassword(passwordResult.Value);

            if (!_userRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("Cound not update user password"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
