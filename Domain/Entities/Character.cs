using Domain.Common;

namespace Domain.Entities
{
    public class Character: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required Race Race { get; set; }
        public required int LifePoints { get; set; }
        public required int SoulsPoints { get; set; }
        public required int StaminaPoints { get; set; }
        public required IReadOnlyList<Personality> Personalities { get; set; }
        public required IReadOnlyList<Restriction> Restrictions { get; set; }
        public required IReadOnlyList<Attribute> Attributes { get; set; }
        public IReadOnlyList<Skill>? Skills { get; set; }
        public required IReadOnlyList<Soul> Souls { get; set; }
        public IReadOnlyList<Talent>? Talents { get; set; }
        public required IReadOnlyList<Action>? Actions { get; set; }
    }
}
