using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.Validations.Users
{
    public class UnregisterValidator : AbstractValidator<UnregisterRequest>
    {
        public UnregisterValidator()
        {
            RuleFor(x => x.Reason)
         .NotEmpty()
         .WithMessage("Delete reason is mandatory.");
        }
    }
}
