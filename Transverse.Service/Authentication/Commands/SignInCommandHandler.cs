using CSharpFunctionalExtensions;
using Survey.Common.Auth;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using System.Linq;

namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class SignInCommandHandler : ICommandHandler<SignInCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public SignInCommandHandler(IEncrypter encrypter,
                                    IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public Result Handle(SignInCommand command)
        {
            var user = _userRepository.FindBy(a => a.Email == command.Email).FirstOrDefault();
            if (user == null)
                return Result.Failure("No user found for Email/Password");
            else
            {
                if (!user.VerifyPassword(command.Password, _encrypter))
                    return Result.Failure("Incorrect password");
            }
            return Result.Ok();
        }
    }
}
