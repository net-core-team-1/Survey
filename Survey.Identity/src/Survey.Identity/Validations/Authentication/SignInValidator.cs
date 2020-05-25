using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Authentication
{
    public class SignInValidator : AbstractValidator<SignInRequest>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Email)
           .NotEmpty()
           .WithMessage("Email is mandatory.");

            RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("Password is mandatory.");
        }
    }
}
