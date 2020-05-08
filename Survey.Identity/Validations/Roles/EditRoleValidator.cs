using FluentValidation;
using Survey.Identity.Contracts;

namespace Survey.Identity.API.Validations.Features
{
    public class EditRoleValidator : AbstractValidator<EditRoleRequest>
    {
        public EditRoleValidator()
        {
            RuleFor(x => x.Name)
             .NotEmpty()
             .WithMessage("Label is mandatory.");
        }
    }
}
