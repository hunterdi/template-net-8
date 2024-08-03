using Domain.Behaviors;

namespace MappingValidation.Models.Queries
{
    public record RoleQuery : BaseResultQuery<long>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
