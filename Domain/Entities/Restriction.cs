using Domain.Common;

namespace Domain.Entities;

public class Restriction: BaseEntity<Guid>
{
    public required string Name { get; set; }
    public required IReadOnlyList<Attribute> Attributes { get; set; }
    public required Metric Metric { get; set; }
}
