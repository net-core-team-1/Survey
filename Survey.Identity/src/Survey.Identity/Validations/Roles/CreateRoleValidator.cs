using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class CreateRoleValidator : AbstractValidator<CreateRoleRequest>
    {
        public CreateRoleValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Label is mandatory.");

        }
    }
}
