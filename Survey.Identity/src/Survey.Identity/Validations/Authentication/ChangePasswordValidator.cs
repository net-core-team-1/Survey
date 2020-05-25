using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Authentication
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
    {
        public ChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword)
           .NotEmpty()
           .WithMessage("New password is mandatory.");

            RuleFor(x => x.OldPassword)
           .NotEmpty()
           .WithMessage("Old Password is mandatory.");
        }
    }
}
