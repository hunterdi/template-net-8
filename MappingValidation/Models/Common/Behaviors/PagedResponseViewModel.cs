namespace MappingValidation.Models.Common.Behaviors
{
    public record PagedResponseViewModel<TDTO, TKey>(int CurrentPage, int TotalPages, int PageSize, int TotalRecords, bool HasPrevious, bool HasNext, IReadOnlyList<TDTO>? Result) where TDTO : QueryResultViewModel<TKey> where TKey : IComparable;
}
