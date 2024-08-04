using Domain.Behaviors;

namespace MappingValidation.Models.Messages
{
    public class CreatedUserMessage : Notification
    {
        public CreatedUserMessage(string message) : base("ANY", "ANY1", "ANY2", "ANY3", message)
        {
        }
    }
}
