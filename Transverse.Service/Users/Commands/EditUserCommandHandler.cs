using CSharpFunctionalExtensions;
using Survey.Common.Types;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Result Handle(EditUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Result.Failure($"No user found for Id= {command.Id}");

            Result<FullName> fullNameResult = FullName.Create(command.FirstName, command.LastName);
            if (fullNameResult.IsFailure)
                return Result.Failure($"FirstName/LastName invalid ");

            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return Result.Failure($"Email invalid ");
            
            user.EditUser(fullNameResult.Value, emailResult.Value, command?.Permissions, command.DeleteExistingPermission);
            if (!_userRepository.Save())
                return Result.Failure($"No user found for Id= {command.Id}");
            return Result.Ok();
        }
    }
}
