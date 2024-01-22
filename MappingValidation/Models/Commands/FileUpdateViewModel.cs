using MappingValidation.Models.Common.Behaviors;
using Microsoft.AspNetCore.Http;

namespace MappingValidation.Models.Commands
{
    public record FileUpdateViewModel(
        string Path, 
        IReadOnlyList<IFormFile>? Files, 
        Guid Id, 
        bool IsActive, 
        bool IsVisible
    ) : UpdateCommandViewModel<Guid>(Id, IsActive, IsVisible);
}
