using Domain.Common;

namespace Domain.Entities;

public class Restriction: BaseEntity<Guid>
{
    public required string Name { get; set; }
    public required virtual IReadOnlyList<Attribute> Attributes { get; set; }
    public required virtual Metric Metric { get; set; }
}
