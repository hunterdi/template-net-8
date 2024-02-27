using Domain.Common;

namespace Domain.Entities
{
    public class VirtualCalculation: BaseEntity<Guid>
    {
        public virtual required IReadOnlyCollection<Metric> Metrics { get; set; }
    }
}
