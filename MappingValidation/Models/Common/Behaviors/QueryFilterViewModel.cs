namespace MappingValidation.Models.Common.Behaviors
{
    public record QueryFilterViewModel(bool? IsActive, DateTimeOffset? CreatedAt, DateTimeOffset? UpdatedAt, bool? IsVisible, bool? IsDeleted, DateTimeOffset? DeletedAt);
}
