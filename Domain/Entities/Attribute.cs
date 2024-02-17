using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Attribute: BaseEntity<Guid>
    {
        public int BaseValue { get; set; }
        public int VariableValue { get; set; }
        public IReadOnlyList<Metric>? ModifiedMetrics { get; set; }
        public int? ModifiedValue { get; set; }
        public required TypeAttribute Type { get; set; }
    }
}

// Soul: Emissão(Transmissor), Manipulação(Domador), Conjuração(Conjurador), Transmutação(Transmorfo), Aprimoramento(Aprimorador/Reforço), Especialização(Divergente).
// Character: Força, Velocidade, Constitução, Carisma, Sabedoria, Inteligência, Sorte, Concentração.