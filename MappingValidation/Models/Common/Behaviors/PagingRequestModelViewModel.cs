namespace MappingValidation.Models.Common.Behaviors
{
    public record PagingRequestModelViewModel<TDTO>(int PageNumber = 1, int PageSize = 10, string OrderBy = "CreatedAt", bool OrderByDescending = true, TDTO? Filter = null) where TDTO : QueryFilterViewModel;
}
