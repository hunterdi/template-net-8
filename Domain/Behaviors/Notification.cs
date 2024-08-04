using MediatR;

namespace Domain.Behaviors
{
    public abstract class Notification : INotification
    {
        private readonly string _from = string.Empty;
        private readonly string _to = string.Empty;
        private readonly string _message = string.Empty;
        private readonly string _queue = string.Empty;
        private readonly string _topic = string.Empty;

        public Notification(string from, string to, string queue, string topic, string message)
        {
            _from = from;
            _to = to;
            _queue = queue;
            _topic = topic;
            _message = message;
        }
    }
}
