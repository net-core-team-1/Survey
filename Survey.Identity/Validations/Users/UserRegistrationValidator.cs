using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.Validations.Users
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationRequest>
    {
        public UserRegistrationValidator()
        {
            RuleFor(x => x.FirstName)
           .NotEmpty()
           .WithMessage("FirstName is mandatory.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName is mandatory.");

            RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is mandatory.");
        }
    }
}
