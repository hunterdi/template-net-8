using MappingValidation.Models.Commands;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAsync(UserCreateCommand command);
        Task SignOutAsync(long id);
        Task<SignInResponseCommand> SignInAsync(SignInRequestCommand command);
    }
}
