using Infrastructure.Behaviors.Attributes;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Business.Services;
using MediatR;
using MappingValidation.Models.Commands;

namespace RPGApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public AuthenticateController(IUserService userService, IMediator sender, ILogger<AuthenticateController> logger)
        {
            _userService = userService;
            _logger = logger;
            _mediator = sender;
        }

        [HttpPost, AllowAnonymous]
        public async Task<ActionResult<IdentityResult>> Create([FromBody] UserCreateCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet("signout/{id}")]
        public async Task<IActionResult> SignOut([FromRoute] long id)
        {
            await _userService.SignOutAsync(id);

            return Ok();
        }

        [HttpPost("signin"), AllowAnonymous]
        public async Task<ActionResult<SignInResponseCommand>> SignIn([FromBody] SignInRequestCommand request)
        {
            var response = await _userService.SignInAsync(request);

            return Ok(response);

        }

        [HttpGet, Permission(Module.AUTHENTICATE, Permission.VIEW)]
        public async Task<IActionResult> Get()
        {
            await Task.Run(() => { });
            return Ok(Task.CompletedTask);
        }
    }
}
