using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Tag: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required string Value { get; set; }
        public Guid ConfigurationId { get; set; }
        public virtual required TagConfiguration Configuration { get; set; }
        public Guid MetricId { get; set; }
        public virtual required Metric Metric { get; set; }
    }
}
