using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Domain.Enums;
using System.Security.Claims;
using Domain.Extensions;

namespace Infrastructure.Behaviors.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class PermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly Permission _permission;
        private readonly Module _module;
        
        public PermissionAttribute(Module module, Permission permission)
        {
            _module = module;
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user == null)
            {
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
                throw new UnauthorizedAccessException("Access denied");
            }

            if (!user.Claims.Any(e => e.Type == ClaimTypes.AuthenticationMethod && e.Value.Contains($"{_module.EnumKeyNormalize()}.{_permission.EnumKeyNormalize()}"))) throw new UnauthorizedAccessException("Permission denied");
        }
    }
}
