using Domain.Behaviors;
using Domain.Enums;

namespace MappingValidation.Models.Queries
{
    public record UserQuery : BaseResultQuery<long>
    {
        public required string FullName { get; set; }
        public required string Email { get; set; }
        public DateOnly? BirthDate { get; set; }
        public Roles Role { get; set; }
    }
}
