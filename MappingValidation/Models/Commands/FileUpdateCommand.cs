using MediatR;
using Microsoft.AspNetCore.Http;

namespace MappingValidation.Models.Commands
{
    public record FileUpdateCommand : IRequest<long>
    {
        public required string Path { get; set; }
        public IReadOnlyList<IFormFile>? Files { get; set; }
    }
}
