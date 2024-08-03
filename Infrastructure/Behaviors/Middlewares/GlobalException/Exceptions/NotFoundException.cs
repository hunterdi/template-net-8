using Domain.Enums;

namespace Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(Module module, Permission permission, ErrorCode errorCode) : base(module, permission, errorCode)
        {
        }
    }
}
