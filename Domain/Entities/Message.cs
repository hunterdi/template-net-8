using Domain.Behaviors;

namespace Domain.Entities
{
    public class Message: BaseEntity<long>
    {
        public required string Command { get; set; }
        public required long OwnerId { get; set; }
        public virtual required User Owner { get; set; }
        public required long RoomId { get; set; }
        public virtual required Room Room { get; set; }
    }
}
