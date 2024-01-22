using AutoMapper;
using Domain.Common;
using MappingValidation.Models.Common.Behaviors;
using Repository.Common.Behaviors;

namespace Service.Common.Behaviors
{
    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : IBaseEntity<TKey> where TKey : IComparable
    {
        protected readonly IBaseRepository<TEntity, TKey> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity, TKey> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public virtual async Task<TQueryResultDTO> CreateAsync<TQueryResultDTO, TCreateCommandDTO>(TCreateCommandDTO dto, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TCreateCommandDTO : CreateCommandViewModel
        {
            var entity = this._mapper.Map<TEntity>(dto);

            var resultRepository = await this._repository.AddAsync(entity, cancellationToken);

            await this._repository.SaveChangeAsync(cancellationToken);

            var result = this._mapper.Map<TQueryResultDTO>(resultRepository);

            return result;
        }

        public virtual async Task<IReadOnlyCollection<TQueryResultDTO>> CreateAsync<TQueryResultDTO, TCreateCommandDTO>(IEnumerable<TCreateCommandDTO> dtos, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TCreateCommandDTO : CreateCommandViewModel
        {
            var entities = this._mapper.Map<TEntity[]>(dtos);

            var resultRepository = await this._repository.AddRangeAsync(entities, cancellationToken);

            await this._repository.SaveChangeAsync(cancellationToken);

            var result = this._mapper.Map<TQueryResultDTO[]>(resultRepository);

            return result;
        }

        public virtual async Task RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await this._repository.GetByIdAsync(id);

            if (entity == null) throw new Exception();

            await this._repository.DeleteAsync(entity, cancellationToken);
            await this._repository.SaveChangeAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync<TUpdateCommandDTO>(TKey id, TUpdateCommandDTO dto, CancellationToken cancellationToken = default) where TUpdateCommandDTO : UpdateCommandViewModel<TKey>
        {
            var entity = await this._repository.GetByIdAsync(id);

            if (entity == null) throw new Exception();

            var entityMapped = this._mapper.Map(dto, entity);

            await this._repository.UpdateAsync(entityMapped, cancellationToken);
            await this._repository.SaveChangeAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync<TUpdateCommandDTO>(IEnumerable<TUpdateCommandDTO> dtos, CancellationToken cancellationToken = default) where TUpdateCommandDTO : UpdateCommandViewModel<TKey>
        {
            var entityMapped = this._mapper.Map<TEntity[]>(dtos);

            if (entityMapped == null) throw new Exception();

            var tasks = entityMapped.Select(e =>
            {
                return this._repository.UpdateAsync(e, cancellationToken);
            });

            await Task.WhenAll(tasks);
            await this._repository.SaveChangeAsync(cancellationToken);
        }

        public virtual async Task<PagedResponseViewModel<TQueryResultDTO, TKey>> GetPagedAsync<TQueryResultDTO, TQueryFilterDTO>(PagingRequestModelViewModel<TQueryFilterDTO> pagingRequestDTO, CancellationToken cancellationToken = default) where TQueryResultDTO : QueryResultViewModel<TKey> where TQueryFilterDTO : QueryFilterViewModel
        {
            var modelMapped = this._mapper.Map<PagingRequestModel<TEntity, TKey>>(pagingRequestDTO);

            var resultRepository = await this._repository.GetPagedAsync(modelMapped, cancellationToken: cancellationToken);

            var resultMapped = this._mapper.Map<PagedResponseViewModel<TQueryResultDTO, TKey>>(resultRepository);

            return resultMapped;
        }

        public virtual async Task<TQueryResultDTO> GetByIdAsync<TQueryResultDTO>(TKey id) where TQueryResultDTO : QueryResultViewModel<TKey>
        {
            var resultRepository = await this._repository.GetByIdAsync(id);
            var resultMapped = this._mapper.Map<TQueryResultDTO>(resultRepository);

            return resultMapped;
        }
    }
}
