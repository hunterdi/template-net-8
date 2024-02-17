using Domain.Common;

namespace Domain.Entities
{
    public class VirtualCalculation: BaseEntity<Guid>
    {
        public required IReadOnlyCollection<Metric> Metrics { get; set; }
    }
}
