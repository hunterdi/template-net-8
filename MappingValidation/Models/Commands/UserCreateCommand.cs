using Domain.Behaviors;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace MappingValidation.Models.Commands
{
    public record UserCreateCommand : CreateCommand<IdentityResult>
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateOnly? BirthDate { get; set; }
        public Roles Role { get; set; }
    }
}
