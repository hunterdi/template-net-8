namespace MappingValidation.Models.Common.Behaviors
{
    public record UpdateCommandViewModel<TKey>(TKey Id, bool IsActive, bool IsVisible) where TKey : IComparable;
}
