using Domain.Behaviors;
using Domain.Enums;

namespace MappingValidation.Models.Commands
{
    public record FileFilterCommand : BaseFilterCommand
    {
        public string? PersistedName { get; set; }
        public string? RealName { get; set; }
        public FileExtensions? Extension { get; set; }
        public int? Length { get; set; }
        public string? Path { get; set; }
        public required byte[] Content { get; set; }
        public required string ContentType { get; set; }
    }
}
