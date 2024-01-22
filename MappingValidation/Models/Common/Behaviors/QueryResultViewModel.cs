namespace MappingValidation.Models.Common.Behaviors
{
    public record QueryResultViewModel<TKey>(TKey Id, bool IsActive, DateTimeOffset CreatedAt, DateTimeOffset UpdatedAt, bool IsVisible, bool IsDeleted, DateTimeOffset? DeletedAt) where TKey : IComparable;
}
