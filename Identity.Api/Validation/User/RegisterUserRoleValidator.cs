using FluentValidation;
using Identity.Api.Contrats.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Api.Validation.User
{
    public class RegisterUserRoleValidator : AbstractValidator<RegisterUserRoleRequest>
    {
    }
}
