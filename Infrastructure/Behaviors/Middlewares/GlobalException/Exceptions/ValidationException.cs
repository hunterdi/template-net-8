using Domain.Enums;

namespace Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(Module module, Permission permission, ErrorCode errorCode) : base(module, permission, errorCode)
        {
        }
    }
}
