using Domain.Common;

namespace Domain.Entities
{
    public class Character: BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public required int Age { get; set; }
        public required virtual Race Race { get; set; }
        public required int LifePoints { get; set; }
        public required int SoulsPoints { get; set; }
        public required int StaminaPoints { get; set; }
        public required virtual IReadOnlyList<Personality> Personalities { get; set; }
        public required virtual IReadOnlyList<Restriction> Restrictions { get; set; }
        public required virtual IReadOnlyList<Attribute> Attributes { get; set; }
        public virtual IReadOnlyList<Skill>? Skills { get; set; }
        public required virtual IReadOnlyList<Soul> Souls { get; set; }
        public virtual IReadOnlyList<Talent>? Talents { get; set; }
        public virtual IReadOnlyList<Action>? Actions { get; set; }
    }
}
