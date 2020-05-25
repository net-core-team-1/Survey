using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.Validations.Users
{
    public class EditUserValidator : AbstractValidator<EditUserInfoRequest>
    {
        public EditUserValidator()
        {
            RuleFor(x => x.FirstName)
           .NotEmpty()
           .WithMessage("FirstName is mandatory.");

            RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("LastName is mandatory.");

        }
    }
}
