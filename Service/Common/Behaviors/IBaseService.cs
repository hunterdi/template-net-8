using Domain.Common;
using MappingValidation.Models.Common.Behaviors;

namespace Service.Common.Behaviors
{
    public interface IBaseService<TEntity, TKey> where TEntity: IBaseEntity<TKey> where TKey : IComparable
    {
        Task<TQueryResultDTO> CreateAsync<TQueryResultDTO, TCreateCommandDTO>(TCreateCommandDTO dto, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TCreateCommandDTO : CreateCommandViewModel;
        Task<IReadOnlyCollection<TQueryResultDTO>> CreateAsync<TQueryResultDTO, TCreateCommandDTO>(IEnumerable<TCreateCommandDTO> dtos, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TCreateCommandDTO : CreateCommandViewModel;
        Task RemoveAsync(TKey id, CancellationToken cancellationToken = default);
        Task UpdateAsync<TUpdateCommandDTO>(TKey id, TUpdateCommandDTO dto, CancellationToken cancellationToken = default) where TUpdateCommandDTO : UpdateCommandViewModel<TKey>;
        Task UpdateAsync<TUpdateCommandDTO>(IEnumerable<TUpdateCommandDTO> dtos, CancellationToken cancellationToken = default) where TUpdateCommandDTO : UpdateCommandViewModel<TKey>;
        Task<PagedResponseViewModel<TQueryResultDTO, TKey>> GetPagedAsync<TQueryResultDTO, TQueryFilterDTO>(PagingRequestModelViewModel<TQueryFilterDTO> pagingRequestDTO, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TQueryFilterDTO : QueryFilterViewModel;
        Task<TQueryResultDTO> GetByIdAsync<TQueryResultDTO>(TKey id) where TQueryResultDTO : QueryResultViewModel<TKey>;
    }
}
