using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class TagConfiguration: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public Enums.ValueType CastTo { get; set; }
    }
}
