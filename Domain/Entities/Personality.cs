using Domain.Common;

namespace Domain.Entities;

public class Personality: BaseEntity<Guid>
{
    public required string Name { get; set; }
    public required int Value { get; set; }
    public virtual required IReadOnlyList<Attribute> Attributes { get; set; }
}
