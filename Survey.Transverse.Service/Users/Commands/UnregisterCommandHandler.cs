using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using Survey.Transverse.Infrastracture.Data;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class UnregisterCommandHandler : ICommandHandler<UnregisterUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UnregisterCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Handle(UnregisterUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for Id= {command.Id}");

            Result<DeleteInfo> deletionResult = DeleteInfo.Create(command.By, command.Reason);
            if (deletionResult.IsFailure)
                return Result.Failure($"Deletion reason error");

            user.Unregister(deletionResult.Value);
            if (!_userRepository.Save())
            {
                return Result.Failure("User could not be unregistred");
            }
            return Result.Ok();
        }
    }
}
