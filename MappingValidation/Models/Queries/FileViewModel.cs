using Domain.Enums;
using MappingValidation.Models.Common.Behaviors;

namespace MappingValidation.Models.Queries
{
    public record FileViewModel(
        Guid Id,
        bool IsActive,
        DateTimeOffset CreatedAt,
        DateTimeOffset UpdatedAt,
        bool IsVisible,
        bool IsDeleted,
        DateTimeOffset? DeletedAt,
        string PersistedName,
        string RealName,
        FileExtensions Extension,
        int Length,
        string Path,
        byte[] Content,
        string ContentType
    ) :
    QueryResultViewModel<Guid>(Id, IsActive, CreatedAt, UpdatedAt, IsVisible, IsDeleted, DeletedAt);
}
