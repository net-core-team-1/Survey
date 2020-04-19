using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using Survey.Transverse.Domain.Users;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Authentication.Commands
{
    public sealed class SignOutCommandHandler : ICommandHandler<SignOutCommand>
    {
        private readonly IUserRepository _userRepository;

        public SignOutCommandHandler(
                                    IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Result> Handle(SignOutCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Task<Result>.FromResult(Result.Failure($"No user found for {command.Id}"));
            user.SetLastConnexionDate();
            _userRepository.Save();
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
