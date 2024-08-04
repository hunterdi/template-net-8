using MappingValidation.Models.Messages;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace MappingValidation.Models.Notifications
{
    public class CreateUserNotify : INotificationHandler<CreatedUserMessage>
    {
        private readonly ILogger _logger;

        public CreateUserNotify(ILogger<CreateUserNotify> logger)
        {
            _logger = logger;
        }

        public Task Handle(CreatedUserMessage notification, CancellationToken cancellationToken)
        {
            var notificationSerialized = JsonSerializer.Serialize(notification);

            _logger.LogDebug($"HANDLER_NOTIFY[NOTIFICATION]:{notificationSerialized}");

            return Task.CompletedTask;
        }
    }
}
