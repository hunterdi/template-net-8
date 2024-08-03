using Business.Services;
using MappingValidation.Models.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Business.Handlers
{
    public sealed class CreateUserHandler : IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            this._userService = userService;
        }

        public async Task<IdentityResult> Handle(UserCreateCommand command, CancellationToken cancellationToken)
        {
            var result = await this._userService.CreateAsync(command);
            return result;
        }
    }
}
