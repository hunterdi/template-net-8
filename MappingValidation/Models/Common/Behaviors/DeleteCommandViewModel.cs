namespace MappingValidation.Models.Common.Behaviors
{
    public record DeleteCommandViewModel<TKey>(TKey Id) where TKey : IComparable;
}
