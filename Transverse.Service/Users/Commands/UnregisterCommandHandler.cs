using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class UnregisterCommandHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UnregisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Result> Handle(UnregisterUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Task<Result>.FromResult(Result.Failure($"No user found for Id= {command.Id}"));

            Result<DeleteInfo> deletionResult = DeleteInfo.Create(command.By, command.Reason);
            if (deletionResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Deletion reason error"));

            user.Unregister(deletionResult.Value);
            if (!_userRepository.Save())
            {
                return Task<Result>.FromResult(Result.Failure("User could not be unregistred"));
            }
            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
