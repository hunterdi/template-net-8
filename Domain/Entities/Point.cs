using Domain.Common;

namespace Domain.Entities
{
    public class Point: BaseEntity<Guid>
    {
        public virtual required Metric Metric { get; set; }
        public decimal Value { get; set; }
        public decimal ReferenceValue { get; set; }
        public required string Origin { get; set; }
    }
}
