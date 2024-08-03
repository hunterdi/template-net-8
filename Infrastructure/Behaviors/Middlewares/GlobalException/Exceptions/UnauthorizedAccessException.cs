using Domain.Enums;

namespace Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions
{
    public class UnauthorizedAccessException : BaseException
    {
        public UnauthorizedAccessException(Module module, Permission permission, ErrorCode errorCode) : base(module, permission, errorCode)
        {
        }
    }
}
