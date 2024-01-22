using MappingValidation.Models.Common.Behaviors;
using Microsoft.AspNetCore.Http;

namespace MappingValidation.Models.Commands
{
    public record FileCreateViewModel(
        IFormFile File,
        bool IsActive,
        bool IsVisible
    ) : CreateCommandViewModel(IsActive, IsVisible);
}
