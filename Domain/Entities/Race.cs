using Domain.Common;

namespace Domain.Entities;

public class Race: BaseEntity<Guid>
{
    public required string Name { get; set; }
}
