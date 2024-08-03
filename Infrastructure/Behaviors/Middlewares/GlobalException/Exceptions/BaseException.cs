using Domain.Enums;
using Domain.Extensions;

namespace Infrastructure.Behaviors.Middlewares.GlobalException.Exceptions
{
    public abstract class BaseException : Exception
    {
        private readonly IReadOnlyList<string> _errors;

        public BaseException(Module module, Permission permission, ErrorCode errorCode)
        {
            var error = $"{module.EnumKeyNormalize()}.{permission.EnumKeyNormalize()}.{errorCode.EnumKeyNormalize()}";
            _errors = new List<string> { error };
        }

        public IReadOnlyList<string> Errors => _errors;
    }
}
