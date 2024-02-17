using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Requirement: BaseEntity<Guid>
    {
        public TypeRequirement Type { get; set; }
        public required Restriction Restriction { get; set; }
        public required IReadOnlyList<Metric> Metrics { get; set; }
    }
}
