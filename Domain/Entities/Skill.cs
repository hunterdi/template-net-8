using Domain.Common;

namespace Domain.Entities
{
    public class Skill: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required virtual Requirement Requirement { get; set; }
        public required virtual IReadOnlyList<Metric> Metrics { get; set; }
    }
}

// Ativo, Passivo
// Área, Direcionado, Multiplos, Aleatório
