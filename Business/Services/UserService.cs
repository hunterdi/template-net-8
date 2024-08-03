using AutoMapper;
using Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions;
using Domain.Entities;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using UnauthorizedAccessException = Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions.UnauthorizedAccessException;
using Domain.Extensions;
using MappingValidation.Models.Commands;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IRoleService _roleService;
        private readonly IJwtService _jwtService;
        private readonly ILogger _logger;

        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IRoleService roleService, IJwtService jwtService, IMapper mapper, ILogger<UserService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleService = roleService;
            _jwtService = jwtService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IdentityResult> CreateAsync(UserCreateCommand command)
        {
            var userMapped = _mapper.Map<User>(command) ?? throw new Exception("");

            var role = command.Role.EnumKeyNormalize();

            await _userManager.CreateAsync(userMapped, command.Password.ApplyHash());
            var response = await _userManager.AddToRoleAsync(userMapped, role);

            return response;
        }

        public async Task SignOutAsync(long id)
        {
            var credential = await _userManager.FindByIdAsync(id.ToString()) ?? throw new NotFoundException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            await _signInManager.SignOutAsync();
        }

        public async Task<SignInResponseCommand> SignInAsync(SignInRequestCommand command)
        {
            var user = await _userManager.FindByEmailAsync(command.Email) ?? throw new NotFoundException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            var authenticated = await _signInManager.CheckPasswordSignInAsync(user, command.Password.ApplyHash(), false);

            if (!authenticated.Succeeded) throw new UnauthorizedAccessException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            var signInResult = await _signInManager.PasswordSignInAsync(user, command.Password.ApplyHash(), false, false);

            if (!signInResult.Succeeded) throw new UnauthorizedAccessException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            var roles = (await _userManager.GetRolesAsync(user)) ?? throw new UnauthorizedAccessException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            var claims = (await _roleService.GetClaimsAsync(roles.AsReadOnly())) ?? throw new UnauthorizedAccessException(Module.AUTHENTICATE, Permission.VIEW, ErrorCode.SERVICE);

            var token = _jwtService.GetJwtToken(user, claims);

            _logger.LogDebug(token);

            var response = new SignInResponseCommand
            {
                Token = token
            };

            return response;
        }
    }
}
