using Domain.Behaviors;
using MappingValidation.Models.Queries;
using Microsoft.AspNetCore.Http;

namespace MappingValidation.Models.Commands
{
    public record FileCreateCommand : CreateCommand<FileQuery>
    {
        public required IFormFile File { get; set; }
    }
}
