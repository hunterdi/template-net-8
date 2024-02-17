using Domain.Common;

namespace Domain.Entities
{
    public class Action: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required Requirement Requirement { get; set; }
        public required IReadOnlyList<Metric> Metrics { get; set; }
    }
}

// Andar, Correr, Saltar, Arremessar, Empurrar, Desviar, Atacar, Contra-Atacar...