using CSharpFunctionalExtensions;
using Survey.CQRS.Commands;
using Survey.Transverse.Domain.Users;
using Survey.Transverse.Domain.Users.Commands;
using System.Threading.Tasks;

namespace Survey.Transverse.Service.Users.Commands
{
    public sealed class EditUserCommandHandler : ICommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public EditUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Result> Handle(EditUserCommand command)
        {
            var user = _userRepository.FindByKey(command.Id);
            if (user == null)
                return Task<Result>.FromResult(Result.Failure($"No user found for Id= {command.Id}"));

            Result<FullName> fullNameResult = FullName.Create(command.FirstName, command.LastName);
            if (fullNameResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"FirstName/LastName invalid "));

            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.IsFailure)
                return Task<Result>.FromResult(Result.Failure($"Email invalid "));
            
            user.EditUser(fullNameResult.Value, emailResult.Value, command?.Permissions, command.DeleteExistingPermission);
            if (!_userRepository.Save())
                return Task<Result>.FromResult(Result.Failure($"No user found for Id= {command.Id}"));

            return Task<Result>.FromResult(Result.Ok());
        }
    }
}
