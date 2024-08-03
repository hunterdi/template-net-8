using Domain.Enums;

namespace Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException(Module module, Permission permission, ErrorCode errorCode) : base(module, permission, errorCode)
        {

        }
    }
}
