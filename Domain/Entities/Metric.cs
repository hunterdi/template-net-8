using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Metric: BaseEntity<Guid>
    {
        public TypeConfiguration Name { get; set; }
        public virtual required IReadOnlyCollection<Tag> Tags { get; set; }
        public virtual IReadOnlyCollection<Point>? Points { get; set; }
    }
}
