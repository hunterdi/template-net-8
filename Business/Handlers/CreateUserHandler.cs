using Business.Services;
using MappingValidation.Models.Commands;
using MappingValidation.Models.Messages;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Business.Handlers
{
    public sealed class CreateUserHandler : IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly IUserService _userService;
        private readonly IMediator _mediator;
        private readonly ILogger<CreateUserHandler> _logger;

        public CreateUserHandler(IUserService userService, IMediator mediator, ILogger<CreateUserHandler> logger)
        {
            this._userService = userService;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IdentityResult> Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation("HANDLER_COMMAND[START]");

            var result = await this._userService.CreateAsync(command);

            _logger.LogInformation("HANDLER_COMMAND[FINISHED]");

            var message = new CreatedUserMessage("FUNFA");
            await _mediator.Publish(message, cancellationToken);

            return result;
        }
    }
}
