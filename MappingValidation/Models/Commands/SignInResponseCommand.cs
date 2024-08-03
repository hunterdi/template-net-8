
using Domain.Behaviors;

namespace MappingValidation.Models.Commands
{
    public record SignInResponseCommand : CreateQuery
    {
        public required string Token { get; set; }
    }
}
