using FluentValidation;
using MappingValidation.Models.Commands;

namespace MappingValidation.Validations
{
    public class CreateUserValidator: AbstractValidator<UserCreateCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(p => p.Email).NotEmpty().EmailAddress();
            RuleFor(p => p.Role).NotNull().IsInEnum();
            RuleFor(p => p.BirthDate).NotEmpty();
        }
    }
}
