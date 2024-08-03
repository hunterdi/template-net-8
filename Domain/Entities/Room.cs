using Domain.Behaviors;

namespace Domain.Entities
{
    public class Room: BaseEntity<long>
    {
        public required string Name { get; set; }
        public required long OwnerId { get; set; }
        public virtual required User Owner { get; set; }
        public virtual required IReadOnlyCollection<User> Guests { get; set; }
        public virtual required IReadOnlyCollection<Message> Messages { get; set; }
    }
}
