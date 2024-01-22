using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class File: BaseEntity<Guid>
    {
        public required string PersistedName { get; set; }
        public required string RealName { get; set; }
        public required FileExtensions Extension { get; set; }
        public required int Length { get; set; }
        public required string Path { get; set; }
        public required byte[] Content {  get; set; }
        public required string ContentType { get; set; }
    }
}
