using Domain.Behaviors;
using Domain.Enums;

namespace MappingValidation.Models.Queries
{
    public record FileQuery : BaseResultQuery<long>
    {
        public required string PersistedName { get; set; }
        public required string RealName { get; set; }
        public FileExtensions Extension { get; set; }
        public int Length { get; set; }
        public required string Path { get; set; }
        public required byte[] Content { get; set; }
        public required string ContentType { get; set; }
    }
}
