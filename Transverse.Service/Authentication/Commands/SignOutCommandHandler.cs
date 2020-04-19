using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users.Authentication.Commands;
using Survey.Transverse.Domain.Users;


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
        public Result Handle(SignOutCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for {command.Id}");
            user.SetLastConnexionDate();
            _userRepository.Save();
            return Result.Ok();
        }
    }
}
