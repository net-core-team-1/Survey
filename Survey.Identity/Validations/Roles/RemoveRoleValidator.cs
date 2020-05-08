using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class RemoveRoleValidator : AbstractValidator<RemoveRoleRequest>
    {
        public RemoveRoleValidator()
        {
            RuleFor(x => x.Reason)
           .NotEmpty()
           .WithMessage("Reason is mandatory.");

        }
    }
}
